using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioParticleController : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioParticleController Instance;
    public AudioClip collect;
    public AudioClip wrong;

    public ParticleSystem pickup;
    public ParticleSystem trap;

    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else Destroy(gameObject);
    }

   
   
    public void PlaySoundEffect(string soundName, Vector3 position)
    {
        AudioClip clip = null;
        ParticleSystem effect = null;

        if (soundName == "Pickup")
        {
            clip = collect;
            effect = pickup;
        }
        else if (soundName == "trap")
        {
            clip = wrong;
            effect = trap;
        }

        if (clip != null)
        {
            // Create a temporary GameObject
            GameObject tempAudio = new GameObject("TempAudio");
            tempAudio.transform.position = position;

            // Add an AudioSource and play the clip
            AudioSource audioSource = tempAudio.AddComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.Play();

            // Destroy the temporary object after the clip finishes playing
            Destroy(tempAudio, clip.length);
        }

         if (effect != null)
        {
            // Instantiate the particle effect at the same position
            ParticleSystem spawnedEffect = Instantiate(effect, position, Quaternion.identity);
            spawnedEffect.Play();

            // Destroy the particle effect after it finishes
            Destroy(spawnedEffect.gameObject, spawnedEffect.main.duration);
        }
    }
}
