using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionManager : MonoBehaviour
{


    int playerOneLives = 3;
    int playerTwoLives = 3;
    int playerOneAmmo = 0;
    int playerTwoAmmo = 0;

    void Start()
    {
        GameStart();
    }


    void Update()
    {
        
    }


    void GameStart()
    {
        while((playerOneLives > 0) && (playerTwoLives > 0))
        {
            Debug.Log("Welcome to 007, press w to shoot, s to block, or a to reload");
        }
    }


    void GetInput()
    {

    }

    void GetResults()
    {

    }

}
