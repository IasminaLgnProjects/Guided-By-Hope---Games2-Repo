using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeThrow : MonoBehaviour
{
    private bool hasAxe;
    Rigidbody rbAxe;
    [SerializeField] Transform rbAxeTransform;
    float power = 25f; //How fast you throw it
    [SerializeField] Animator animator;
    public Transform target;
    //private bool isReturning = false;
    private Vector3 oldPos;

    GameObject hand;

    void Start()
    {
        rbAxe = GetComponent<Rigidbody>();
        hasAxe = true;
    }
    void Update()
    {
        hand = GameObject.FindGameObjectWithTag("Hand");
        //print("hasAxe is" + hasAxe);
        //print("axe pos is" + rbAxe.position + "target pos is" + target.position);
        
        animator.SetBool("throwTrigger", false);

        if (Input.GetKey(KeyCode.Mouse0) && hasAxe == true)
        {
            animator.SetBool("throwTrigger", true);
            Invoke("Throw", 0.60f); //delay to line with the animation
            hasAxe = false;
        }
        else
        {
            animator.SetBool("throwTrigger", false);
        }

        if (Input.GetKey(KeyCode.Mouse1) && hasAxe == false)
        {
            animator.SetBool("catchTrigger", true);
            Invoke("Return", 0.60f);
            ResetAxe();
            hasAxe = true;
        }
        else
        {
            animator.SetBool("catchTrigger", false);
        }
    }

    public void Throw()
    {
        rbAxe.transform.parent = null;
        rbAxe.isKinematic = false;
        rbAxe.AddForce(Camera.main.transform.TransformDirection(Vector3.forward) * power, ForceMode.Impulse);
        rbAxe.AddTorque(rbAxe.transform.TransformDirection(Vector3.right) * 300, ForceMode.Impulse);
        //isReturning = false;
    }
    void Return()
    {
        //isReturning = true;
        rbAxeTransform.position += target.position - rbAxeTransform.position; //this makes it a linear movement
        rbAxe.velocity = Vector3.zero; //this makes it freeze
        rbAxe.isKinematic = true; //we don't want it to be affected by force anymore
    }


    void ResetAxe()
    {
        //isReturning = false;
        rbAxeTransform.parent = hand.transform;
        //rbAxeTransform.rotation = hand.transform.rotation;

        //Set Rotation

        //Euler angles or transform.rotation
        print("reset");
    }
}
