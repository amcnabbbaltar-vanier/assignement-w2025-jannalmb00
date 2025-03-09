using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public event Action<int> OnScoreChanged;

    private int score = 0;
 
    private void Awake()
    {
        //Debug.Log(Instance == null);
        if(Instance == null){
            Debug.Log("score initialized successfully");
            DontDestroyOnLoad(gameObject);
            Instance = this;
        } 
        else {
            Destroy(gameObject);
        }
    }
    public void AddScore(int addScore){
        score += addScore;
        OnScoreChanged?.Invoke(score);
    }
    public int GetScore() => score;
}
