using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioParticleController : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
         
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other){
        if (audioSource.clip == null){
            Debug.LogError("null audio");
        }
        if (other.CompareTag("Player")){
            Debug.Log("pick");
            audioSource.Play();
        }else if (other.CompareTag("CapsuleTrap")){
            audioSource.Play();
        }
       }
 }
