using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollection : MonoBehaviour
{

    public int score = 50;
  
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ScorePickup"))
        {
            ScoreManager.Instance.AddScore(score);
            AudioParticleController.Instance.PlaySoundEffect("Pickup", other.transform.position);
            Destroy(other.gameObject);
            GameManager.Instance.UpdatePickupText("+ 50");
        }
       

    }
    
}
