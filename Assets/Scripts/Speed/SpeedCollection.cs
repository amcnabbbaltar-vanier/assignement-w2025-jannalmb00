using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedCollection : MonoBehaviour
{
  

    void Start()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpeedPickup")) 
        {
            GameManager.Instance.ActivateSpeedBoost();
            AudioParticleController.Instance.PlaySoundEffect("Pickup", other.transform.position);
            Destroy(other.gameObject);
            Debug.Log("Speed boost activated!");
        }
     
    }
}
