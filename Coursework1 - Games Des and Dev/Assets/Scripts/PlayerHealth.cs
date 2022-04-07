using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int playerHealth = 100;
    public int GetPlayerHealth
    {
        get
        {
            return playerHealth;
        }
    }

    GameManager GameManagerScript;
    [SerializeField] PlayerFalling PlayerFallingScript;

    void Start()
    {
        GameManagerScript = GameObject.Find("TheGameManager").GetComponent<GameManager>();
        PlayerFallingScript = gameObject.GetComponent<PlayerFalling>();
    }
    public void TakeDamage(int damageAmount)
    {
        playerHealth = playerHealth - damageAmount;
        if (playerHealth <= 0)
        {
            KillPlayer();
        }
    }

    void KillPlayer()
    {
        PlayerFallingScript.DeactivateAnimator();
        FindObjectOfType<SoundManager>().PlayAudio("PlayerDeath");
        Invoke("StopGame", 4f);
    }

    void StopGame()
    {
        GameManagerScript.ShowGameOverPanel();
    }
}
