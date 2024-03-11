using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaScript : PickableScript
{
    public int healPercentage;

    protected override void PickUp()
    {
        GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>().playEatingSound();
        GameManager._instance.characterStats.HealPercentage(healPercentage);
        GameManager._instance.metrics.AddBanana();
    }
}
