using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionThrowOLD : MonoBehaviour
{
    private bool hasAxe;
    Rigidbody rbPotion;
    float power = 10f;
    [SerializeField] Animator animator;

    void Start()
    {
        rbPotion = GetComponent<Rigidbody>();
        //animator = GetComponent<Animator>();
    }
    void Update()
    {
        animator.SetBool("potionTrigger", false);
        if (Input.GetKey(KeyCode.E))
        {
            animator.SetBool("potionTrigger", true);
            Invoke("Throw", 0.60f); //delay to line with the animation
        }
    }

    public void Throw()
    {
        rbPotion.isKinematic = false;
        rbPotion.transform.parent = null;
        rbPotion.AddForce(Camera.main.transform.TransformDirection(Vector3.forward) * power, ForceMode.Impulse);
        //rbPotion.AddTorque(rbPotion.transform.TransformDirection(Vector3.right) * 300, ForceMode.Impulse);
    }
}
