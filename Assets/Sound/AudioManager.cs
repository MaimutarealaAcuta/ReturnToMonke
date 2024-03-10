using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    
    public AudioClip combatMusic;
    public AudioClip waitingMusic;
    public AudioClip menuMusic;

    void Start()
    {
        musicSource.clip = combatMusic;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeMusic(AudioClip clip)
    {
        musicSource.clip=clip;
        musicSource.Play();
    }
}
