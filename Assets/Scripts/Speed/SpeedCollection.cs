using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedCollection : MonoBehaviour
{
    private CharacterMovement playerMovement;
    private float speedTimer = 0f;
    private float speedCoolDown = 5f;
    private bool canSpeedUp = false;
    

    void Start()
    {
        playerMovement = GetComponent<CharacterMovement>();
        //audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpeedPickup")) 
        {
            playerMovement.speedMultiplier = 3f;
            speedTimer = 0f;
            canSpeedUp = true;

            Debug.Log("Speed boost activated!");
            Destroy(other.gameObject);
             GameManager.Instance.UpdatePickupText("Speed booster activated for 5s");
        }
     
    }

    void Update()
    {
        if (canSpeedUp)
        {
            speedTimer += Time.deltaTime;
            GameManager.Instance.UpdateSpeedBoosterTime("Speed: " +(int)speedTimer);
            Debug.Log("Timer: " + speedTimer);

            if (speedTimer > speedCoolDown)
            {
                playerMovement.speedMultiplier = 1f;
                canSpeedUp = false;
                Debug.Log("Speed boost ended.");
                GameManager.Instance.UpdateSpeedBoosterTime("");
                
            }
        }
    }
}
