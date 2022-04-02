using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthCanvas : MonoBehaviour
{
    [SerializeField] public Slider slider;
    GameObject player;
    PlayerHealth playerHealthScript;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerHealthScript = player.GetComponent<PlayerHealth>();
            slider.value = playerHealthScript.GetPlayerHealth();
        }
    }

    private void LateUpdate() //late update because the player takes damage in Update
    {
        slider.value = playerHealthScript.GetPlayerHealth();
        //print("Slider value is " + slider.value);
    }
}
