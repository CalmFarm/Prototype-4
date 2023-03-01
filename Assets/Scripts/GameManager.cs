using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    public GameObject titleScreen;
    // Start is called before the first frame update
    void Start()
    {
        isGameActive=false;
    }

    public void StartGame()
    {
        isGameActive=true;
        titleScreen.gameObject.SetActive(false);
    }
}
