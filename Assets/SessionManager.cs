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
    public TextMeshProUGUI playerOneLivesText;
    public TextMeshProUGUI playerOneAmmoText;
    public TextMeshProUGUI playerTwoLivesText;
    public TextMeshProUGUI playerTwoAmmoText;
    public Button blockbutton;
    public Button reloadButton;
    public Button shootButton;

    bool playerOneHasAmmo = false;
    bool playerTwoHasAmmo = false;

    public AudioClip reloadSound;
    public AudioClip shootSound;

    void Start()
    {
        playerOneLivesText.text = "Player 1 Lives: " + playerOneLives.ToString();
        playerOneAmmoText.text = "Player 1 Ammo: " + playerOneAmmo.ToString();
        playerTwoLivesText.text = "Player 2 Lives: " + playerTwoLives.ToString();
        playerTwoAmmoText.text = "Player 2 Ammo: " + playerTwoAmmo.ToString();
        blockbutton.onClick.AddListener(Block);
        reloadButton.onClick.AddListener(Reload);
        shootButton.onClick.AddListener(Shoot);
    }


    void Update()
    {
        playerOneHasAmmoCheck();
        playerTwoHasAmmoCheck();
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
            playerTwoAmmo ++;
            updateNumbers();
            AudioSource.PlayClipAtPoint(reloadSound, Camera.main.transform.position);
            return "Player 2 reloads";
        }
        else if(playerSelection == 1 && computerSelection == 3 && playerTwoHasAmmo)
        {
            playerTwoAmmo --;
            updateNumbers();
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position);
            return "Player 1 blocks the shot!";
        }
        else if(playerSelection == 2 && computerSelection == 1)
        {
            playerOneAmmo ++;
            updateNumbers();
            AudioSource.PlayClipAtPoint(reloadSound, Camera.main.transform.position);
            return "Player 1 reloads!";
        }
        else if(playerSelection == 2 && computerSelection == 2)
        {
            playerOneAmmo ++;
            playerTwoAmmo ++;
            updateNumbers();
            AudioSource.PlayClipAtPoint(reloadSound, Camera.main.transform.position);
            return "Both players reload!";
        }
        else if(playerSelection == 2 && computerSelection == 3 && playerTwoHasAmmo)
        {
            playerOneLives --;
            playerTwoAmmo --;
            updateNumbers();
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position);
            return "Player 1 is shot!";
        }
        else if(playerSelection == 3 && computerSelection == 1 && playerOneHasAmmo)
        {
            playerOneAmmo --;
            updateNumbers();
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position);
            return "Player 2 blocks!";
        }
        else if(playerSelection == 3 && computerSelection == 2 && playerOneHasAmmo)
        {
            playerTwoLives --;
            playerOneAmmo --;
            updateNumbers();
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position);
            return "Player 2 is shot!";
        }
        else if(playerSelection == 3 && computerSelection == 3 && playerOneHasAmmo)
        {
            playerOneAmmo --;
            playerTwoAmmo --;
            updateNumbers();
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position);
            return "Both players shoot!";
        }
        // below is for if they shoot with no ammo
        else if(playerSelection == 1 && computerSelection == 3 && !playerTwoHasAmmo)
        {
            return "Player 2 has no ammo!";
        }
        else if(playerSelection == 2 && computerSelection == 3 && !playerTwoHasAmmo)
        {
            playerOneAmmo ++;
            updateNumbers();
            AudioSource.PlayClipAtPoint(reloadSound, Camera.main.transform.position);
            return "Player 1 reloads, player two has no ammo!";
        }
        else if(playerSelection == 3 && computerSelection == 1 && !playerOneHasAmmo)
        {
            return "Player 2 blocks, player 1 has no ammo!";
        }
        else if(playerSelection == 3 && computerSelection == 2 && !playerOneHasAmmo)
        {
            playerTwoAmmo ++;
            updateNumbers();
            AudioSource.PlayClipAtPoint(reloadSound, Camera.main.transform.position);
            return "Player 2 reloads, player 1 has no ammo!";
        }
        else if(playerSelection == 3 && computerSelection == 3 && !playerOneHasAmmo && !playerTwoHasAmmo)
        {
            return "Neither players have ammo!";
        }
        else if(playerSelection == 3 && computerSelection == 3 && !playerOneHasAmmo && playerTwoHasAmmo)
        {
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position);
            return "Player 1 is shot! And has no ammo!";
        }
        else if(playerSelection == 3 && computerSelection == 3 && playerOneHasAmmo && !playerTwoHasAmmo)
        {
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position);
            return "Player 2 is shot! And has no ammo!";
        }
        else
        {
            return "wooopdeedoo!";
        }


    }

    void updateNumbers()
    {
        playerOneLivesText.text = "Player 1 Lives: " + playerOneLives.ToString();
        playerOneAmmoText.text = "Player 1 Ammo: " + playerOneAmmo.ToString();
        playerTwoLivesText.text = "Player 2 Lives: " + playerTwoLives.ToString();
        playerTwoAmmoText.text = "Player 2 Ammo: " + playerTwoAmmo.ToString();
    }

    void playerOneHasAmmoCheck()
    {
        if(playerOneAmmo > 0)
        {
            playerOneHasAmmo = true;
        }
        else if(playerOneAmmo == 0)
        {
            playerOneHasAmmo = false;
        }
    }
    
    void playerTwoHasAmmoCheck()
    {
        if(playerTwoAmmo > 0)
        {
            playerTwoHasAmmo = true;
        }
        else if(playerTwoAmmo == 0)
        {
            playerTwoHasAmmo = false;
        }
    }

}
