using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaScript : PickableScript
{
    public int healPercentage;
    
    protected override void PickUp()
    {
        GameManager._instance.characterStats.HealPercentage(healPercentage);
    }
}
