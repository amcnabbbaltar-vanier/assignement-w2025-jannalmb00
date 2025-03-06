using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        if(ScoreManager.Instance != null)
        {
            ScoreManager.Instance.OnScoreChanged += UpdateScoreUI;
            UpdateScoreUI(ScoreManager.Instance.GetScore());
        }
        
    }
    private void UpdateScoreUI(int newScore)
    {
        scoreText.text = "Score: " + newScore;
        Debug.Log(newScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
