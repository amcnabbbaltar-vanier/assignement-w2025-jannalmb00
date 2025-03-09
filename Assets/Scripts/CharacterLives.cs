using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterLives : MonoBehaviour
{
    public float lives = 3;
    private bool isGameOver = false;

    // Update is called once per frame
    void Update()
    {
        if(isGameOver){
            SceneManager.LoadScene("EndScene");
        }
        
    }
    public void LoseLife()
    {
        if(!isGameOver && lives >= 0){
            lives --;
            if(lives <= 0){
                isGameOver = true;
            }

        }
    }

    public void AddLife(){
        if(isGameOver){
            lives++;
        }
    }
}
