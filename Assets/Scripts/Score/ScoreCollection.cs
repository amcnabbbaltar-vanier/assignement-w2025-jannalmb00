using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollection : MonoBehaviour
{

    public int score = 50;
    //private AudioSource audioSource;
    
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ScorePickup"))
        {
            ScoreManager.Instance.AddScore(score);
            Destroy(other.gameObject);
            //audioSource.Play();
             GameManager.Instance.UpdatePickupText("+ 50");
        }
       

    }
    
}
