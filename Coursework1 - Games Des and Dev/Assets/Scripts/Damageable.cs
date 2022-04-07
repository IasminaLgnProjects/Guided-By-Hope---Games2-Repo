using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Damageable : MonoBehaviour
{
    private float health = 100; 
    WitchPatrol WitchPatrolScript;
    Animator witchAnimator;
    Collider witchCollider;
    NavMeshAgent witchNMAgent;


    [SerializeField] ColliderDetector ColliderDetectorScript;

    void Start()
    {
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
                DealDamage(100);
            }

            if (health <= 0)
            {
                FindObjectOfType<SoundManager>().PlayAudio("WitchDeath");
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

    void KillEnemy()
    {
        witchCollider.enabled = false;
        witchAnimator.enabled = false;
        WitchPatrolScript.enabled = false;
        witchNMAgent.enabled = false;
    }
}
