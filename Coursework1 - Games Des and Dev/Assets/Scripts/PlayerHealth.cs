using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHealth;
    //[SerializeField] GameObject GameOverPanel;

    GameManager GameManagerScript;
    SoundManager SoundManagerScript;
    [SerializeField] PlayerFalling PlayerFallingScript;
    Animator playerAnimator;



    void Start()
    {
        //GameOverPanel.SetActive(false);
        SoundManagerScript = GameObject.Find("TheSoundManager").GetComponent<SoundManager>();
        GameManagerScript = GameObject.Find("TheGameManager").GetComponent<GameManager>();
        PlayerFallingScript = gameObject.GetComponent<PlayerFalling>();
        playerAnimator = gameObject.GetComponent<Animator>();
    }
    public void TakeDamage(int damageAmount)
    {
        playerHealth = playerHealth - damageAmount;
        if (playerHealth <= 0)
        {
            KillPlayer();
            //GameOverPanel.SetActive(true);
        }
    }

    void KillPlayer()
    {
        //replace it with a rig 
        //make sound 

        SoundManagerScript.AudioPlayerDeath();
        PlayerFallingScript.DeactivateAnimator();
        //playerAnimator.enabled = false;
        Invoke("StopGame", 4f);
        //Destroy(gameObject);
    }

    public int GetPlayerHealth() //better to call it by a public function than make the var public 
    {
        return playerHealth;
    }

    void StopGame()
    {
        //reference to the game manager 
        GameManagerScript.ShowGameOverPanel();
    }
}
