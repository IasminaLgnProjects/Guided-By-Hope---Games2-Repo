using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetector : MonoBehaviour
{
    private bool axeCollided;
    public bool getAxeCollided
    {
        get
        {
            return axeCollided;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //print("collision");
        //print(other.gameObject.name);
        if (other.gameObject.tag == "Axe")
        {
            //print("axe hit");
            axeCollided = true;
        }
    }
}
