using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    private int damageAmount = 20;
    PlayerHealth PlayerHealthScript;

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerHealthScript = collision.GetComponent<PlayerHealth>();
            if (PlayerHealthScript != null)
            {
                FindObjectOfType<SoundManager>().PlayAudio("PotionBreak");
                FindObjectOfType<SoundManager>().PlayAudio("PlayerHit");
                PlayerHealthScript.TakeDamage(damageAmount);
            }
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(DestroyObject());
        }
    }

    IEnumerator DestroyObject()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);
            Destroy(gameObject);

            yield return null;
        }
    }
}
