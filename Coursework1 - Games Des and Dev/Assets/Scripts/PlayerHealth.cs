using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHealth;
    //[SerializeField] GameObject GameOverPanel;

    void Start()
    {
        //GameOverPanel.SetActive(false);
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
        
        
        //Destroy(gameObject);
    }

    public int GetPlayerHealth() //better to call it by a public function than make the var public 
    {
        return playerHealth;
    }
}
