using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Security.Cryptography; // for scene change

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}
    private CharacterMovement playerMovement;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI pickupText;
    public TextMeshProUGUI jumpBoostText;
    public TextMeshProUGUI speedBoostText;

    private float pickupDuration = 2f;
    private float pickupTimer = 0f;


    private float jumpTimer = 0f;
    private float jumpCoolDown = 30f;

    private float speedTimer = 0f;
    private float speedCoolDown = 5f;
     private bool canSpeedUp = false;


    public bool isPlaying = false;
    private bool isPickupTextActive = false;
    private float timePlayed = 0f;
    
    private void Awake()
    {
        if (Instance == null){
            DontDestroyOnLoad(gameObject);
             Instance = this;
        }
        else{
             Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if(ScoreManager.Instance != null && TrapManager.Instance != null)
        {
            FindPlayer();
            ScoreManager.Instance.OnScoreChanged += UpdateScoreUI;
            TrapManager.Instance.LiveChanged += UpdateLivesUI;
            TrapManager.Instance.OnGameOver += HandleGameOver;
            UpdateScoreUI(ScoreManager.Instance.GetScore());
            UpdateLivesUI(TrapManager.Instance.GetLives());
        }
        
        
    }
    public void HandleCurrentLevelFailure(){
         TrapManager.Instance.MinusLive();
         
        if(TrapManager.Instance.GetLives() <= 0){
            HandleGameOver();

        }else{
            ScoreManager.Instance.SubtractScore();
             ResetJumpBoost();
            ResetSpeedBoost();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
       
    }
    public void UpdatePickupText(string message){
        pickupText.text = message;
        isPickupTextActive = true;
        pickupTimer = pickupDuration;
        
    }
    public void UpdateJumpBoosterTime(string message){
        jumpBoostText.text = message;
    }
    public void UpdateSpeedBoosterTime(string message){
        speedBoostText.text = message;
    }
    public void ActivateJumpBoost()
    {
        playerMovement.canDoubleJump = true;
        jumpTimer = 0f;
        
        //UpdateJumpBoosterTime("Jump: " + jumpCoolDown + "s");
    }
    public void ActivateSpeedBoost()
    {
        canSpeedUp = true;
        speedTimer = 0f;
        playerMovement.speedMultiplier = 2.0f;
        //UpdateSpeedBoosterTime("Speed: " + speedCoolDown + "s");
    }
    public void ResetJumpBoost()
    {
        playerMovement.canDoubleJump  = false;
        jumpTimer = 0f;
        UpdateJumpBoosterTime("");
    }

    public void ResetSpeedBoost()
    {
        canSpeedUp = false;
        speedTimer = 0f;
        playerMovement.speedMultiplier = 1.0f;
        UpdateSpeedBoosterTime("");
    }
    void FindPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player"); 
        if (player != null)
        {
             Debug.Log("player");
            playerMovement = player.GetComponent<CharacterMovement>();
            Debug.Log(playerMovement == null ? " null movement" : "not null movement");
        }
        else
        {
            Debug.Log("Player not found!");
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
        if (playerMovement == null)  // Ensure player reference is not lost after restart
        {
            FindPlayer();
        }
        if(  playerMovement.canDoubleJump && jumpTimer < jumpCoolDown){
            jumpTimer += Time.deltaTime;
            UpdateJumpBoosterTime("Jump: " + (int)jumpTimer + "s");

        } else{
            ResetJumpBoost();
        }
        
        
        if(canSpeedUp && speedTimer < speedCoolDown){
            speedTimer += Time.deltaTime;
            UpdateSpeedBoosterTime("Speed: " + (int)speedTimer + "s");
        }else{
            ResetSpeedBoost();
        }

        if(isPickupTextActive){
            pickupTimer -= Time.deltaTime;
            if(pickupTimer < 0){
                isPickupTextActive = false;
                pickupText.text = "";
            }
        }

        
    }
}
