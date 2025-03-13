using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCheckpointController : MonoBehaviour
{
    private AudioSource audioSource;  
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            if(TrapManager.Instance.GetLives() > 0){
                Debug.Log("Level up");
                ScoreManager.Instance.SaveScore();
                StartCoroutine(PlaySoundThenLoad());
                
            }

        }
    }
    private IEnumerator PlaySoundThenLoad(){
         Debug.Log(audioSource != null);
        if(audioSource != null){
            audioSource.Play();
            yield return new WaitUntil(() => !audioSource.isPlaying);   
        }
        Debug.Log(SceneManager.GetActiveScene().buildIndex + 1 == 5);
        if(SceneManager.GetActiveScene().buildIndex + 1 == 5){
            GameManager.Instance.isPlaying = false;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
}
