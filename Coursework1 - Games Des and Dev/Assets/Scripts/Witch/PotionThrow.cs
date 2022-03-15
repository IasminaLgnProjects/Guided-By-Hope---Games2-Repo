using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionThrow : MonoBehaviour
{
    [SerializeField] float bulletspeed;
    [SerializeField] Rigidbody2D bullet;
    float offsetX = 1f;
    float offsetY = 0f;
    [SerializeField] public float playerHealth;

    void Start()
    {

    }
    void FireWeapon()
    {
        Rigidbody2D shot;
        shot = Instantiate(bullet, transform.position + new Vector3(offsetX, offsetY, 0f), transform.rotation);
        shot.velocity = new Vector3(1, 0, 0) * bulletspeed;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            FireWeapon();
        }
    }
}
