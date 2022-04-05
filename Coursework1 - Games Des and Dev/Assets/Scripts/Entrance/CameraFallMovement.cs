using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFallMovement : MonoBehaviour
{
    float speed = 100f;
    //Vector3 newLoc = new Vector3(-784, -59, 278);

    [SerializeField] PlayerFalling playerFallingScript;
    //[SerializeField] GameObject point1;
    [SerializeField] GameObject point2;

    void Update()
    {
        print("move");
        //float step = speed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, newLoc, step);

        if(playerFallingScript != null)
        {
            if(playerFallingScript.getCameraMoving)
            {
                print("falling true");
                Lerp();
                //float step = speed * Time.deltaTime;
                //transform.position = Vector3.MoveTowards(point1.transform.position, point2.transform.position, step);
            }
        }

        //float step = speed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, point2.transform.position, step);
    }

    void Lerp()
    {
        print("lerp");
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, point2.transform.position + new Vector3(0, 10f, -3f), step);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
}
