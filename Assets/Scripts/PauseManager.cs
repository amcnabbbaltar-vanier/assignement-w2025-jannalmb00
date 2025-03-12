using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuPanel;
    private bool isPaused = false;
    // Start is called before the first frame update
    void Awake(){
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                ResumeGame();
            }else{
                PauseGame();
            }
            
        }
        
    }
    public void PauseGame(){
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

    }
    public void ResumeGame(){
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;

    }
    public void RestartGame(){
        Time.timeScale = 1.0f;
        isPaused = false; 
        //pauseMenuPanel.SetActive(false);
        ScoreManager.Instance.SubtractScore();
        TrapManager.Instance.RestoreLives();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
