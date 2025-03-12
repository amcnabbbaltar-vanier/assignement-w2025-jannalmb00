using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCollection : MonoBehaviour
{
    private CharacterMovement playerMovement;
    

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<CharacterMovement>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "JumpPickup")
        {
            GameManager.Instance.ActivateJumpBoost();
            AudioParticleController.Instance.PlaySoundEffect("Pickup", other.transform.position);
            Destroy(other.gameObject);
            Debug.Log(playerMovement.canDoubleJump );
            GameManager.Instance.UpdatePickupText("Jump booster activated for 30s");
        }
       
    }

    
}
