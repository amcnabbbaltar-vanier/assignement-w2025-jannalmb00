using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    // UI Elements
    [Header("UI Elements")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI pickupText;
    public TextMeshProUGUI jumpBoostText;
    public TextMeshProUGUI speedBoostText;

    // Player & Game State
    private CharacterMovement playerMovement;
    public bool isPlaying = true;
    private float timePlayed = 0f;
    public float totalTimePlayed = 0f;

    // Pickup & Power-Ups
    [Header("Pickup & Power-Ups")]
    private bool isPickupTextActive = false;
    private float pickupDuration = 2f;
    private float pickupTimer = 0f;

    private float jumpTimer = 0f;
    private float jumpCooldown = 30f;
    private float speedTimer = 0f;
    private float speedCooldown = 5f;
    private bool canSpeedUp = false;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (ScoreManager.Instance != null && TrapManager.Instance != null)
        {
            FindPlayer();
            ScoreManager.Instance.OnScoreChanged += UpdateScoreUI;
            TrapManager.Instance.LiveChanged += UpdateLivesUI;
            TrapManager.Instance.OnGameOver += HandleGameOver;
            UpdateScoreUI(ScoreManager.Instance.GetScore());
            UpdateLivesUI(TrapManager.Instance.GetLives());
        }
    }

    // Player & Scene Management
    private void FindPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerMovement = player.GetComponent<CharacterMovement>();
        }
    }

    public void HandleCurrentLevelFailure()
    {
        TrapManager.Instance.MinusLive();
        if (TrapManager.Instance.GetLives() <= 0)
        {
            HandleGameOver();
        }
        else
        {
            ScoreManager.Instance.SubtractScore();
            ResetJumpBoost();
            ResetSpeedBoost();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void HandleGameOver()
    {
        Debug.Log("Game Over! Loading end scene...");
        totalTimePlayed = timePlayed;
        ResetJumpBoost();
        ResetSpeedBoost();
        UpdateTimeUI(totalTimePlayed);
        Time.timeScale = 0f;
        ResetTime();
        SceneManager.LoadScene("EndScene");
    }

    // UI Updates
    private void UpdateScoreUI(int newScore)
    {
        scoreText.text = "Score: " + newScore;
    }

    private void UpdateLivesUI(int lives)
    {
        livesText.text = "Lives: " + lives;
    }

    private void UpdateTimeUI(float time)
    {
        int min = (int)(time / 60f);
        int sec = (int)(time % 60f);
        timeText.text = string.Format("{0:00}:{1:00}", min, sec);
    }

    public void ResetAllUI()
    {
        scoreText.text = "Score: 0";
        livesText.text = "Lives: 3";
        ResetTime();
    }

    public void ResetTime()
    {
        timePlayed = 0;
    }

    // Power-Ups
    public void ActivateJumpBoost()
    {
        playerMovement.canDoubleJump = true;
        jumpTimer = 0f;
    }

    public void ActivateSpeedBoost()
    {
        canSpeedUp = true;
        speedTimer = 0f;
        playerMovement.speedMultiplier = 2.0f;
    }

    public void ResetJumpBoost()
    {
        playerMovement.canDoubleJump = false;
        jumpTimer = 0f;
        jumpBoostText.text = "";
    }

    public void ResetSpeedBoost()
    {
        canSpeedUp = false;
        speedTimer = 0f;
        playerMovement.speedMultiplier = 1.0f;
        speedBoostText.text = "";
    }

    // Pickup Text
    public void UpdatePickupText(string message)
    {
        pickupText.text = message;
        isPickupTextActive = true;
        pickupTimer = pickupDuration;
    }

    public void UpdateJumpBoosterTime(string message)
    {
        jumpBoostText.text = message;
    }

    public void UpdateSpeedBoosterTime(string message)
    {
        speedBoostText.text = message;
    }

    private void Update()
    {
        if (isPlaying)
        {
            timePlayed += Time.deltaTime;
            //totalTimePlayed = timePlayed;
            UpdateTimeUI(timePlayed);
        }

        if (playerMovement == null)
        {
            FindPlayer();
        }

        if (playerMovement.canDoubleJump && jumpTimer < jumpCooldown)
        {
            jumpTimer += Time.deltaTime;
            UpdateJumpBoosterTime("Jump: " + (int)jumpTimer + "s");
        }
        else
        {
            ResetJumpBoost();
        }

        if (canSpeedUp && speedTimer < speedCooldown)
        {
            speedTimer += Time.deltaTime;
            UpdateSpeedBoosterTime("Speed: " + (int)speedTimer + "s");
        }
        else
        {
            ResetSpeedBoost();
        }

        if (isPickupTextActive)
        {
            pickupTimer -= Time.deltaTime;
            if (pickupTimer < 0)
            {
                isPickupTextActive = false;
                pickupText.text = "";
            }
        }
    }
}
