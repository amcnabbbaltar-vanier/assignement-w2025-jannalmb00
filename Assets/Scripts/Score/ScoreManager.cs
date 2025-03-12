using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public event Action<int> OnScoreChanged;

    private int levelScore = 0;
    private int totalScore = 5;

 
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
        levelScore += addScore;
        totalScore += addScore;
        OnScoreChanged?.Invoke(totalScore);
    }
    public void SubtractScore()
    {
        totalScore -= levelScore;
        levelScore = 0;
        OnScoreChanged?.Invoke(totalScore);
    }
   
    public int GetScore() => totalScore;
}
