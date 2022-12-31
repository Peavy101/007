using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SessionManager : MonoBehaviour
{


    int playerOneLives = 3;
    int playerTwoLives = 3;
    int playerOneAmmo = 0;
    int playerTwoAmmo = 0;

    public TextMeshProUGUI resultText;
    public Button blockbutton;
    public Button reloadButton;
    public Button shootButton;

    void Start()
    {
        blockbutton.onClick.AddListener(Block);
        reloadButton.onClick.AddListener(Reload);
        shootButton.onClick.AddListener(Shoot);
    }


    void Update()
    {
        
    }

    void Block()
    {
        int playerSelection = 1;
        int computerSelection = Random.Range(1, 4);
        resultText.text = DetermineWinner(playerSelection, computerSelection);
    }
    void Reload()
    {
        int playerSelection = 2;
        int computerSelection = Random.Range(1, 4);
        resultText.text = DetermineWinner(playerSelection, computerSelection);
    }
    void Shoot()
    {
        int playerSelection = 3;
        int computerSelection = Random.Range(1, 4);
        resultText.text = DetermineWinner(playerSelection, computerSelection);
    }

    string DetermineWinner(int playerSelection, int computerSelection)
    {
        if(playerSelection == 1 && computerSelection == 1)
        {
            return "Both block!";
        }
        else if(playerSelection == 1 && computerSelection == 2)
        {
            return "Player 2 reloads";
        }
        else if(playerSelection == 1 && computerSelection == 3)
        {
            return "Player 1 blocks the shot!";
        }
        else if(playerSelection == 2 && computerSelection == 1)
        {
            return "Player 1 reloads!";
        }
        else if(playerSelection == 2 && computerSelection == 2)
        {
            return "Both players reload!";
        }
        else if(playerSelection == 2 && computerSelection == 3)
        {
            return "Player 1 is shot!";
        }
        else if(playerSelection == 3 && computerSelection == 1)
        {
            return "Player 2 blocks!";
        }
        else if(playerSelection == 3 && computerSelection == 2)
        {
            return "Player 2 is shot!";
        }
        else if(playerSelection == 3 && computerSelection == 3)
        {
            return "Both players shoot!";
        }
        else
        {
            return "idk how this happened";
        }
    }

}
