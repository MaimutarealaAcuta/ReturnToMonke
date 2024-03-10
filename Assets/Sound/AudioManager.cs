using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource;
    
    public AudioClip combatMusic;
    public AudioClip waitingMusic;

    public AudioClip hitSoundPlayer;
    public AudioClip hitSoundEnemy;

    void Start()
    {
        musicSource.clip = waitingMusic;
        musicSource.Play();
    }

    public void changeMusic(AudioClip clip)
    {
        musicSource.clip=clip;
        musicSource.Play();
    }

    public void playSFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void playButtonSound()
    {
        sfxSource.PlayOneShot(hitSoundPlayer);
     }
}
