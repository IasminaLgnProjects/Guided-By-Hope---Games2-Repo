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
        if (Input.GetKey(KeyCode.O))
        {
            print("O pressed");
            playerAnimator.enabled = false;
            axe.GetComponent<BoxCollider>().enabled = false;
            playerController.enabled = false;
        }

        if (Input.GetKey(KeyCode.P))
        {
            print("P pressed");
            playerAnimator.enabled = true;
            playerController.enabled = true;
        }
    }
}
