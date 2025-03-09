using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // for scene change

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI timeText;
    private float timePlayed = 0f;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        if(ScoreManager.Instance != null && TrapManager.Instance != null)
        {
            ScoreManager.Instance.OnScoreChanged += UpdateScoreUI;
            TrapManager.Instance.LiveChanged += UpdateLivesUI;
            TrapManager.Instance.OnGameOver += HandleGameOver;
            UpdateScoreUI(ScoreManager.Instance.GetScore());
            UpdateLivesUI(TrapManager.Instance.GetLives());
        }
        
    }
    private void UpdateScoreUI(int newScore)
    {
        scoreText.text = "Score: " + newScore;
        Debug.Log(newScore);
    }
    private void UpdateLivesUI(int lives){
        livesText.text = "Lives: " +lives; 
        Debug.Log("lives" +lives);
    }
    private void UpdateTimeUI(){
        int min = (int)(timePlayed / 60f);
        int sec = (int)(timePlayed % 60f);
        timeText.text = string.Format("{0:00}:{1:00}", min, sec);

    }
    private void HandleGameOver()
    {
        Debug.Log("Game Over! Loading end scene...");
        SceneManager.LoadScene("EndScene");
    }

    // Update is called once per frame
    void Update()
    {
        timePlayed += Time.deltaTime; 
        UpdateTimeUI(); 

        
    }
}
