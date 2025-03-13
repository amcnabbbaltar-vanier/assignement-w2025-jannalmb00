using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        
    }
    public void PlayDoubleJumpSound(){
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
