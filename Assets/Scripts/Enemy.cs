using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 3f;
    private Rigidbody enemyRb;
    private GameObject player;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer() //Demonstrate abstraction
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        enemyRb.AddForce(lookDirection * speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
