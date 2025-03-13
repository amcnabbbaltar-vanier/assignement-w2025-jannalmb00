using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuPanel; 
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }

        }
    }

    public void PauseGame()
    {
        if (pauseMenuPanel == null) return;
        
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        if (pauseMenuPanel == null) return;
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }

    public void RestartGame()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
        ScoreManager.Instance.SubtractScore();
        TrapManager.Instance.RestoreLives();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

   

    
}
