using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeScript : MonoBehaviour
{
    [SerializeField] int damageAmount = 100;
    Damageable DamageableScript;
    [SerializeField] GameObject SoundManager;

    // Start is called before the first frame update
    void Start()
    {
        SoundManager = GameObject.Find("TheSoundManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //print(collision.gameObject.name);
        //print("Collided");
        if (collision.gameObject.tag == "Witch")
        {
            print("witch hit");
            DamageableScript = collision.gameObject.GetComponent<Damageable>();
            if (DamageableScript != null)
            {
                //SoundManager.GetComponent<SoundManager>().WitchHit(); 
                DamageableScript.DealDamage(damageAmount);

                //DamageableScript.DealDamage(damageAmount);
            }
            //Destroy(gameObject);
        }
    }
}
