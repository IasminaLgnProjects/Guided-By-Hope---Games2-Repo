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
    [SerializeField] bool canShoot;

    WitchPatrol WPatrolScript;

    public Animator anim;

    void Start()
    {
        WPatrolScript = gameObject.GetComponent<WitchPatrol>();
        anim = GetComponent<Animator>();
        canShoot = true;
    }
    void FireWeapon()
    {
        if(canShoot)
        {
            canShoot = false;
            //print(transform.rotation);
            Rigidbody instBullet = Instantiate(potion, gameObject.transform.position + new Vector3(0, 2f, 0), gameObject.transform.rotation); //Quaternion.identity
            //instBullet.velocity = Vector3.forward * 20;
            //instBullet.velocity = new Vector3(0, 0, gameObject.transform.position.z) * 2;


            //instBullet.velocity = (gameObject.transform.position + Vector3.forward) * 20;
            //instBullet.AddForce(Vector3.forward * 300f);


            //instBullet.rotation = Quaternion.LookRotation(gameObject.transform.rotation);

            //Vector3 eulerRotation = new Vector3(instBullet.gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y, instBullet.gameObject.transform.eulerAngles.z);
            //instBullet.rotation = Quaternion.Euler(eulerRotation);

            //shot.rotation = transform.rotation;

            instBullet.AddForce(transform.forward * 20, ForceMode.Impulse); //+ new Vector3(0, 0, -6)

            Invoke("ResetCanShoot", 2f);
        }

    }

    void ResetCanShoot()
    {
        canShoot = true;
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

// function with animation -> invoke another function -> another f with shooting 