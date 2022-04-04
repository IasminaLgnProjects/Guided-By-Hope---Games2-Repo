using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFalling : MonoBehaviour
{
    Animator playerAnimator;
    [SerializeField] GameObject axe;
    TPSController playerController;
    private bool playerFell;


    void Start()
    {
        playerAnimator = gameObject.GetComponent<Animator>();
        playerController = gameObject.GetComponent<TPSController>();
        axe = GameObject.Find("Axe1");
    }

    IEnumerator MyCoroutine()
    {
        while (true)
        {
            if (playerFell)
            {
                DeactivateAnimator();

                yield return new WaitForSeconds(8f); //wait for the player to fall

                ActivateAnimator();
                ChangeLocation();

                playerFell = false;
            }
            else
            {
                break;
            }
            yield return null;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        print("trigger");
        if(other.gameObject.tag == "Fall")
        {
            print("player1");
            playerFell = true;
            StartCoroutine(MyCoroutine());
        }
    }

    void DeactivateAnimator()
    {
        print("Ragdoll deac");
        playerAnimator.enabled = false;
        axe.GetComponent<BoxCollider>().enabled = false;
        playerController.enabled = false;
    }

    void ActivateAnimator()
    {
        print("P pressed");
        playerAnimator.enabled = true;
        playerController.enabled = true;
    }

    void ChangeLocation()
    {
        gameObject.transform.position = new Vector3(-784, -59, 278);
    }
}
