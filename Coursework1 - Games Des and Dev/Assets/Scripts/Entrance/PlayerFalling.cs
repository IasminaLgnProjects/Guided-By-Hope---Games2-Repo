using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFalling : MonoBehaviour
{
    Animator playerAnimator;
    [SerializeField] GameObject axe;
    TPSController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = gameObject.GetComponent<Animator>();
        playerController = gameObject.GetComponent<TPSController>();
        axe = GameObject.Find("Axe1");
    }

    // Update is called once per frame
    void Update()
    {
        //ragdoll activate
        if (Input.GetKey(KeyCode.O))
        {
            print("O pressed");
            playerAnimator.enabled = false;
            axe.GetComponent<BoxCollider>().enabled = false;
            playerController.enabled = false;
        }

        //ragdoll deactivate
        if (Input.GetKey(KeyCode.P))
        {
            print("P pressed");
            playerAnimator.enabled = true;
            playerController.enabled = true;
        }

        //teleport
        if (Input.GetKey(KeyCode.T))
        {
            gameObject.transform.position = new Vector3(-784, -59, 278);
        }
    }
}
