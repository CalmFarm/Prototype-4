using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ClassButton;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    public GameObject titleScreen;
    // Start is called before the first frame update
    void Start()
    {
        isGameActive=false;
    }

    public void StartGame(PlayerClass playerClass)
    {
        switch(playerClass)
        {
            case PlayerClass.Warrior:
                Warrior warrior = new Warrior();
                warrior.Skill();
                break;
            case PlayerClass.Thief:
                Thief thief = new Thief();
                thief.Skill();
                break;
            default:
                break;
        }
        isGameActive=true;
        titleScreen.gameObject.SetActive(false);
    }
}
