using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator animator;
    private CharacterMovement characterMovement;
    public void Start()
    {
        animator = GetComponent<Animator>();
        characterMovement = GetComponent<CharacterMovement>();
    }
    public void LateUpdate()
    {
       UpdateAnimator();
    }

    // TODO Fill this in with your animator calls
    void UpdateAnimator()
    {
        if(animator ==  null || characterMovement == null) return;

        float movementSpeed = characterMovement.groundSpeed;
        animator.SetFloat("CharacterSpeed", movementSpeed );
        animator.SetBool("IsGrounded", characterMovement.IsGrounded);
        //Debug.Log("Animation:" + (characterMovement.jumpCount == 2 ));

        if(!characterMovement.IsGrounded && characterMovement.jumpCount == 2 && characterMovement.canDoubleJump){
            animator.SetTrigger("DoubleJump");
        }
        
    }

}
