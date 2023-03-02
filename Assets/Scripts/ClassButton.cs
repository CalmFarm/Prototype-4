using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassButton : MonoBehaviour
{
    private Button wbutton;
    private Button tbutton;
    private GameManager gameManager;
    void Start()
    {
        wbutton = GameObject.Find("WarriorButton").GetComponent<Button>();
        tbutton = GameObject.Find("ThiefButton").GetComponent<Button>();

        wbutton.onClick.AddListener(() => ChoiceClass(PlayerClass.Warrior));
        tbutton.onClick.AddListener(() => ChoiceClass(PlayerClass.Thief));

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void ChoiceClass(PlayerClass playerClass)
    {
        gameManager.StartGame(playerClass);
    }

    public enum PlayerClass
{
    Warrior,
    Thief
}
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
