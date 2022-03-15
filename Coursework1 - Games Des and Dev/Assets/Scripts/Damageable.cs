using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] SoundManager SoundManagerScript;

    void Start()
    {
        //SoundManagerScript = SoundManagerObject.GetComponent<TheSoundEffectsManager>();

    }
    public void DealDamage(float damageAmount)
    {
        health = health - damageAmount;
        if (health <= 0)
        {
            PlaySound();
            Destroy(gameObject);
        }
    }

    void PlaySound()
    {
        if (gameObject.tag == "Witch")
        {
            SoundManagerScript.AudioWitchDeath();
        }
        else if (gameObject.tag == "Troll")
        {
            SoundManagerScript.AudioTrollDeath();
        }
    }
}
