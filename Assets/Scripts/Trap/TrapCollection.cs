using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCollection : MonoBehaviour
{
  
   
    
    private void OnTriggerEnter(Collider other)
    {
       // Debug.Log("Triggered by: " + other.name); 
        if (other.CompareTag("CapsuleTrap"))
        {
            if (TrapManager.Instance != null)
            {
                TrapManager.Instance.MinusLive();
            }
            else
            {
                Debug.LogError("TrapManager is not initialized!");
            }
             AudioParticleController.Instance.PlaySoundEffect("trap", other.transform.position);
            Destroy(other.gameObject);
            GameManager.Instance.UpdatePickupText("- 1 life");
        }
    }
    
}
