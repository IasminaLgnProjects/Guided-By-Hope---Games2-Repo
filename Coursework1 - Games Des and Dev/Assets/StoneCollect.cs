using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneCollect : MonoBehaviour
{
    [SerializeField] GameObject PressEPanel;
    [SerializeField] GameManager GameManagerScript;

    void Start()
    {
        PressEPanel.SetActive(false);
        GameManagerScript = GameObject.Find("TheGameManager").GetComponent<GameManager>();
    }

    IEnumerator StoneCollectCoroutine()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                PressEPanel.SetActive(false);
                yield return new WaitForSeconds(2f);
                GameManagerScript.ShowWinPanel();
            }
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PressEPanel.SetActive(true);
            StartCoroutine(StoneCollectCoroutine());
        }
    }
}
