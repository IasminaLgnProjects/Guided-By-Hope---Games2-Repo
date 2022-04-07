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
        if (other.gameObject.tag == "Axe")
        {
            axeCollided = true;
        }
    }
}
