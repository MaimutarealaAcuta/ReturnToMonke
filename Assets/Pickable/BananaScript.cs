using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaScript : PickableScript
{
    public int healPercentage;

    private AudioManager audioManager;
    
    private new void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    protected override void PickUp()
    {
        audioManager.playSFX(audioManager.eatingSound);
        GameManager._instance.characterStats.HealPercentage(healPercentage);
        GameManager._instance.metrics.AddBanana();
    }
}
