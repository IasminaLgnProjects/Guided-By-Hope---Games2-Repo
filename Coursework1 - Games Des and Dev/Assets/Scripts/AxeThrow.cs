using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeThrow : MonoBehaviour
{
    private bool hasAxe;
    Rigidbody rbAxe;
    [SerializeField] Transform rbAxeTransform;
    float power = 25f; 
    [SerializeField] Animator animator;
    public Transform target;
    GameObject hand;

    void Start()
    {
        rbAxe = GetComponent<Rigidbody>();
        hasAxe = true;
    }
    void Update()
    {
        hand = GameObject.FindGameObjectWithTag("Hand");
        
        animator.SetBool("throwTrigger", false);

        if (Input.GetKey(KeyCode.Mouse0) && hasAxe == true)
        {
            animator.SetBool("throwTrigger", true);
            Invoke("Throw", 0.60f);
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

        FindObjectOfType<SoundManager>().PlayAudio("AxeSound");
    }
    void Return()
    {
        rbAxeTransform.position += target.position - rbAxeTransform.position; 
        rbAxe.velocity = Vector3.zero; 
        rbAxe.isKinematic = true; 
    }


    void ResetAxe()
    {
        rbAxeTransform.parent = hand.transform;
    }
}
