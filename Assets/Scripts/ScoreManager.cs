using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public event Action<int> OnScoreChanged;

    private int score = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        //Debug.Log(Instance == null);
        if(Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    public void AddScore(int addScore){
        score += addScore;
        OnScoreChanged?.Invoke(score);
    }
    public int GetScore() => score;
}
