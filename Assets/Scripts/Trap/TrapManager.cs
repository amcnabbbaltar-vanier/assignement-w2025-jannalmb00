using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class TrapManager : MonoBehaviour
{
    public static TrapManager Instance;
    public event Action<int> LiveChanged;
    public event Action OnGameOver;
    private int lives = 3;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("TrapManager initialized successfully");
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    public void MinusLive()
    {
        lives--;
        LiveChanged?.Invoke(lives);
        Debug.Log("lives: " + lives);
        if(lives <= 0) 
        {
            OnGameOver?.Invoke();
        }
        
    }
    public int GetLives() => lives;

    private void OnDestroy()
    {
        Debug.Log("TrapManager is being destroyed on: " + gameObject.name);
        if (Instance == this)
        {
            Debug.Log("The active TrapManager instance is being destroyed!");
            // Instance = null; // Uncomment if you want to reset the instance
        }
    }
}
