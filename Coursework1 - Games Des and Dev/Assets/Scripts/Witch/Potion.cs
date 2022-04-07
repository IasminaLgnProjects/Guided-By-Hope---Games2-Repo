using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    [SerializeField] int damageAmount;
    Damageable DamageableScript; //you might want this to be the PLAYER HEALTH 
    PlayerHealth PlayerHealthScript;
    //[SerializeField] GameObject SoundManager; //delete serial
    [SerializeField] SoundManager SoundManagerScript; //delete serial

    void Start()
    {
        //SoundManager = GameObject.Find("TheSoundManager");
        SoundManagerScript = GameObject.Find("TheSoundManager").GetComponent<SoundManager>();
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
                //          SoundManagerScript.AudioPotionBreak(); 
                FindObjectOfType<SoundManager>().PlayAudio("PotionBreak");
                PlayerHealthScript.TakeDamage(damageAmount);
                
                //DamageableScript.DealDamage(damageAmount);
            }
            Destroy(gameObject);
        }
        else
        {
            //Invoke Destroy after few seconds !!!!!!
        }
    }
}
