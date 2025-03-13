using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuContoller : MonoBehaviour
{

    public void StartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //GameManager.Instance.isPlaying = true;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void BackMenuPage(){
        TrapManager.Instance.RestoreLives();
        ScoreManager.Instance.ResetScore();
        SceneManager.LoadScene("MainMenu");
    }

}
