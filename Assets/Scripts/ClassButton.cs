using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ChoiceClass);

        gameManager=GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void ChoiceClass(){
        gameManager.StartGame();
    }
}
