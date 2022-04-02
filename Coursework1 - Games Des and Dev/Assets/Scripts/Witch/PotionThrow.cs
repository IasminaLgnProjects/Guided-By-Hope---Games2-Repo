using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionThrow : MonoBehaviour
{
    [SerializeField] float throwSpeed =2f;
    [SerializeField] Rigidbody potion;
    float offsetX = 1f;
    float offsetY = 0f;
    float offsetZ = 1f;
    [SerializeField] public float playerHealth;

    WitchPatrol WPatrolScript;

    public Animator anim;

    void Start()
    {
        WPatrolScript = gameObject.GetComponent<WitchPatrol>();
        anim = GetComponent<Animator>();
    }
    void FireWeapon()
    {
        //print(transform.rotation);
        Rigidbody instBullet = Instantiate(potion, gameObject.transform.position + new Vector3(0, 2f, 0), gameObject.transform.rotation); //Quaternion.identity
        instBullet.velocity = Vector3.forward * 20;
        //instBullet.AddForce(Vector3.forward * 300f);
        
        //shot.rotation = transform.rotation;
    }

    void Update()
    {
        if(WPatrolScript.getThrowPotion)
        {
            Debug.Log("True");
            //FireWeapon();


            anim.SetBool("Throwing", true);
            Invoke("FireWeapon", 0.5f);
        }
        else
        {
            anim.SetBool("Throwing", false);
        }
    }
}
