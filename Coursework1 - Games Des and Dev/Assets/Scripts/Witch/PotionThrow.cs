using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionThrow : MonoBehaviour
{
    [SerializeField] float throwSpeed = 20f;
    [SerializeField] Rigidbody potion;
    bool canShoot;

    WitchPatrol WPatrolScript;
    public Animator anim;

    void Start()
    {
        WPatrolScript = gameObject.GetComponent<WitchPatrol>();
        anim = GetComponent<Animator>();
        canShoot = true;

        StartCoroutine(MyCoroutine());
    }

    IEnumerator MyCoroutine()
    {
        while (true)
        {
            if (WPatrolScript.getThrowPotion)
            {
                if (!canShoot)
                {
                    yield return new WaitForSeconds(2f);
                }
                else
                {
                    anim.SetBool("Throwing", true);

                    yield return new WaitForSeconds(1.5f); //wait to align animation

                    canShoot = false;
                    Rigidbody instBullet = Instantiate(potion, gameObject.transform.position + new Vector3(0, 2f, 0), gameObject.transform.rotation);
                    instBullet.AddForce(transform.forward * throwSpeed, ForceMode.Impulse);
                    anim.SetBool("Throwing", false); //keep walking in between shots 

                    yield return new WaitForSeconds(2f); //wait before reseting the shooting

                    canShoot = true; 
                }
            }
            else
            {
                anim.SetBool("Throwing", false);
            }
            yield return null;
        }
    }
}