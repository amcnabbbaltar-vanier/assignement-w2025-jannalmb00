using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartWholeGameManager : MonoBehaviour
{
    public void RestartWholeGame(){
        GameManager.Instance.isPlaying = true;
        GameManager.Instance.ResetAllUI();
        ScoreManager.Instance.ResetScore();
        TrapManager.Instance.RestoreLives();
        SceneManager.LoadScene("Level1");
        
    }
}
