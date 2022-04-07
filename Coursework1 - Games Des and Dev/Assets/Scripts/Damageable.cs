using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Damageable : MonoBehaviour
{
    [SerializeField] float health; //delete ser
    SoundManager SoundManagerScript; 
    WitchPatrol WitchPatrolScript;
    Animator witchAnimator;
    Collider witchCollider;
    NavMeshAgent witchNMAgent;


    [SerializeField] ColliderDetector ColliderDetectorScript;

    void Start()
    {
        SoundManagerScript = GameObject.Find("TheSoundManager").GetComponent<SoundManager>();
        WitchPatrolScript = gameObject.GetComponent<WitchPatrol>();
        witchAnimator = gameObject.GetComponent<Animator>();
        witchCollider = gameObject.GetComponent<Collider>();
        witchNMAgent = gameObject.GetComponent<NavMeshAgent>();
        
        StartCoroutine(MyCoroutine());
    }

    IEnumerator MyCoroutine()
    {
        while(true)
        {
            if (ColliderDetectorScript.getAxeCollided)
            {
                //print("axe collided");
                DealDamage(100);
            }

            if (health <= 0)
            {
                PlaySound();
                KillEnemy();

                yield return new WaitForSeconds(10f);

                Destroy(gameObject);
            }
            yield return null;
        }
    }

    public void DealDamage(float damageAmount)
    {
        health = health - damageAmount;
    }

    void PlaySound()
    {
        if (gameObject.tag == "Witch")
        {
            //SoundManagerScript.AudioWitchDeath();
            FindObjectOfType<SoundManager>().PlayAudio("WitchDeath");
        }
        /*else if (gameObject.tag == "Troll")
        {
            SoundManagerScript.AudioTrollDeath();
        }*/
    }

    void KillEnemy()
    {
        witchCollider.enabled = false;
        witchAnimator.enabled = false;
        WitchPatrolScript.enabled = false;
        witchNMAgent.enabled = false;
    }
}
