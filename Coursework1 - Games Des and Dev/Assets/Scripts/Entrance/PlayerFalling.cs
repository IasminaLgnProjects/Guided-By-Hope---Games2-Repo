using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFalling : MonoBehaviour
{
    Animator playerAnimator;
    [SerializeField] GameObject axe;
    TPSController playerController;
    private bool playerFell;

    [SerializeField] Camera fallingCamera;

    private bool cameraMoving;
    public bool getCameraMoving
    {
        get
        {
            return cameraMoving;
        }
    }

    void Start()
    {
        playerAnimator = gameObject.GetComponent<Animator>();
        playerController = gameObject.GetComponent<TPSController>();
        axe = GameObject.Find("Axe1");

        fallingCamera.enabled = false;
    }

    IEnumerator MyCoroutine()
    {
        while (true)
        {
            if (playerFell)
            {
                DeactivateAnimator();
                ActivateFallingCamera();

                yield return new WaitForSeconds(10f); //wait for the player to fall

                ActivateAnimator();
                ChangeLocation();
                DeactivateFallingCamera();

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

    public void DeactivateAnimator()
    {
        print("Ragdoll deac");
        playerAnimator.enabled = false;
        axe.GetComponent<BoxCollider>().enabled = false;
        playerController.enabled = false;
    }

    void ActivateFallingCamera()
    {
        fallingCamera.enabled = true;
        cameraMoving = true;
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

    void DeactivateFallingCamera()
    {
        fallingCamera.enabled = false;
        cameraMoving = false;
    }
}
