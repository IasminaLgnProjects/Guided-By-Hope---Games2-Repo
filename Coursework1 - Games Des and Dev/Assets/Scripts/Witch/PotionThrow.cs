using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionThrow : MonoBehaviour
{
    [SerializeField] float throwSpeed = 20f;
    [SerializeField] Rigidbody potion;
    [SerializeField] bool canShoot;

    WitchPatrol WPatrolScript;
    public Animator anim;

    void Start()
    {
        WPatrolScript = gameObject.GetComponent<WitchPatrol>();
        anim = GetComponent<Animator>();
        canShoot = true;

        StartCoroutine(MyCoroutine());
        print(WPatrolScript.getThrowPotion);
    }

    IEnumerator MyCoroutine()
    {
        //print(WPatrolScript.getThrowPotion);
        while (true)
        {
            //print(WPatrolScript.getThrowPotion);
            if (WPatrolScript.getThrowPotion)
            {
                //print("canShoot is " + canShoot);
                if (!canShoot)
                {
                    //print("can NOT shoot");
                    yield return new WaitForSeconds(2f);
                }
                else
                {
                    //print("can shoot");
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