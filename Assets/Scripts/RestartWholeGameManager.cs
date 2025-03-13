using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RestartWholeGameManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public void RestartWholeGame(){
        GameManager.Instance.isPlaying = true;
        GameManager.Instance.ResetAllUI();
        ScoreManager.Instance.ResetScore();
        TrapManager.Instance.RestoreLives();
        SceneManager.LoadScene("Level1");
        
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + ScoreManager.Instance.GetScore();
    }
}
