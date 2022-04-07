using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFallMovement : MonoBehaviour
{
    float speed = 100f;

    [SerializeField] PlayerFalling playerFallingScript;
    [SerializeField] GameObject point2;

    void Update()
    {
        if(playerFallingScript != null)
        {
            if(playerFallingScript.getCameraMoving)
            {
                Lerp();
            }
        }
    }

    void Lerp()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, point2.transform.position + new Vector3(0, 10f, -3f), step);
    }
}
