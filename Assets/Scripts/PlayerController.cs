using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    private float powerupStrength = 15f;
    private float verticalInput;

    public bool hasPowerup = false;

    private Rigidbody playerRb;
    private GameObject focalPoint;
    public GameObject powerupIndicator;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        
        ExitGame();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            hasPowerup = true;
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.gameObject.SetActive(true);
        }
        IEnumerator PowerupCountdownRoutine()
        {
            yield return new WaitForSeconds(7);
            hasPowerup = false;
            powerupIndicator.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = other.gameObject.transform.position - transform.position;

            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);

            // Debug.Log("Collided with: " + other.gameObject.name + " with power set up to " + hasPowerup);
        }
    }

    public void ExitGame()
    {
        if (transform.position.y < -10)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    }

    // private void Move()
    // {
    //     float forwardInput = Input.GetAxis("Vertical");
    //     playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);

    //     powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    // }

    public class Job // Inheritance Demonstration
    {
        private string name;
        private int health;

        public string Name //Demonstrate encapsulation
        {
            get { return name; }
            set { name = value; }
        }

        public int Health //Demonstrate encapsulation
        {
            get { return health; }
            set { health = value; }
        }

        public virtual void Skill()
        {
            Debug.Log("use the skill!");
        }
    }

    public class Warrior : Job
    {
        public override void Skill() // overriding
        {
            Debug.Log("powerupStrength is doubled!");
        }
        
    }

    public class Thief : Job
    {
        public override void Skill() // overriding
        {
            Debug.Log("skill cooltime reduce half!");
        }
    }
}
