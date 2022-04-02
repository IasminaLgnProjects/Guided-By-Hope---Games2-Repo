using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    [SerializeField] int damageAmount;
    Damageable DamageableScript; //you might want this to be the PLAYER HEALTH 
    PlayerHealth PlayerHealthScript;
    [SerializeField] GameObject SoundManager;

    void Start()
    {
        SoundManager = GameObject.Find("TheSoundManager");
    }

    void OnTriggerEnter(Collider collision)
    {
        //print(collision.gameObject.name);
        if(collision.gameObject.tag == "Player")
        {
            print("player hit");
            PlayerHealthScript = collision.GetComponent<PlayerHealth>();
            if (PlayerHealthScript != null)
            {
                SoundManager.GetComponent<SoundManager>().AudioPotionBreak(); //this is actually for the AXE HIT
                PlayerHealthScript.TakeDamage(damageAmount);
                
                //DamageableScript.DealDamage(damageAmount);
            }
            //Destroy(gameObject);
        }
    }
}
