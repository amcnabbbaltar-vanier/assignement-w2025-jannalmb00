using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedCollection : MonoBehaviour
{
    private CharacterMovement playerMovement;
    private float speedTimer= 0f;
    private float speedCoolDown = 5f;
    private bool canSpeedUp = false;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<CharacterMovement>();
        
    }
    private void OnTriggerEnter(Collider other){
        if(other.transform.tag == "SpeedPickup"){
            playerMovement.speedMultiplier = 3f;
            speedTimer = 0f;
            canSpeedUp = true;
           // Debug.Log( playerMovement.speedMultiplier);
            Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(canSpeedUp)
        {
            speedTimer += Time.deltaTime;
            Debug.Log("TImer: " + speedTimer);
            if(speedTimer > speedCoolDown)
            {
                playerMovement.speedMultiplier = 1f;
                canSpeedUp = false;
            }
        }
        
        
    }
}
