using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject pausePanel;
    [SerializeField] public GameObject gameOverPanel;
    [SerializeField] public GameObject winPanel;
    public bool paused;
    public static bool playerAlive;

    void Start()
    {
        Cursor.visible = false;

        Time.timeScale = 1f;
        paused = false;

        if (pausePanel == null)
        {
            pausePanel = GameObject.Find("PausePanel");
            pausePanel.SetActive(false);
        }
        else
        {
            pausePanel.SetActive(false);
        }

        if (gameOverPanel == null)
        {
            gameOverPanel = GameObject.Find("GameOverPanel");
            gameOverPanel.SetActive(false);
        }
        else
        {
            gameOverPanel.SetActive(false);
        }

        if (winPanel == null)
        {
            winPanel = GameObject.Find("WinPanel");
            winPanel.SetActive(false);
        }
        else
        {
            winPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                Pause();
            }
            else
            {
                UnPause();
            }
        }
    }

    public void UnPause()
    {
        paused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
    }

    public void Pause()
    {
        paused = true;
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
    }

    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
    }

    public void ShowWinPanel()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
    }
}
