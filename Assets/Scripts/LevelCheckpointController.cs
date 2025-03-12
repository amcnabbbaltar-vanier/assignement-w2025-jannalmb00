using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCheckpointController : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("LevelCheckpoint")){
            if(TrapManager.Instance.GetLives() > 0){
                Debug.Log("Level up");
                ScoreManager.Instance.SaveScore();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }

        }
    }
}
