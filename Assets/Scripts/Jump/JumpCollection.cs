using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCollection : MonoBehaviour
{
    private CharacterMovement playerMovement;
    private float jumpTimer = 0f;
    private float jumpCoolDown = 30f;
    //private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        playerMovement = GetComponent<CharacterMovement>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "JumpPickup")
        {
            playerMovement.canDoubleJump = true;
            jumpTimer = 0f;
            Destroy(other.gameObject);
            Debug.Log(playerMovement.canDoubleJump );
            GameManager.Instance.UpdatePickupText("Jump booster activated for 30s");
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(jumpTimer);
        if(playerMovement.canDoubleJump)
        {
            jumpTimer += Time.deltaTime;
            GameManager.Instance.UpdateJumpBoosterTime("Jump: " + (int)jumpTimer);
            if(jumpTimer > jumpCoolDown)
            {
                playerMovement.canDoubleJump = false;
                 GameManager.Instance.UpdateJumpBoosterTime("");
            }
        }
        
    }
}
