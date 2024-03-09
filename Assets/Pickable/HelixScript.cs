using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixScript : PickableScript
{
    public int DNAvalue = 1;
    
    public void setDNAvalue(int baseValue)
    {
        int luckLevel = GameManager._instance.characterStats.GetStatValue(
                            GameManager._instance.skillTree.getSkillName(SkillTree.ESkill.Luck));
        int waveNumber = 1; // get wave number
        DNAvalue = baseValue + (int)(baseValue * luckLevel * 0.1f) + waveNumber;
    }
    
    protected override void PickUp()
    {
        GameManager._instance.dnaScript.add(DNAvalue);
    }
}
