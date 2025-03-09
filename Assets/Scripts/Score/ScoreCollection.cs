using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollection : MonoBehaviour
{

    public int score = 50;
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "ScorePickup")
        {
            ScoreManager.Instance.AddScore(score);
            Destroy(other.gameObject);
        }

    }
    
}
