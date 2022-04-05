using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrrain : MonoBehaviour
{
    private void Awake()
    {
        //GetComponent<TerrainCollider>().enabled = false;
        GetComponent<TerrainCollider>().enabled = true;
    }
}
