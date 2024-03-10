using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTree : MonoBehaviour
{
    public enum ESkill
    {
        Strength,
        Agility,
        Vitality,
        Faith,
        Luck,
        Vision,
        Regen,
        Lighthouse,
        Defense
    };

    string[] skillNames =
    {
        "Strength",
        "Agility",
        "Vitality",
        "Faith",
        "Luck",
        "Vision",
        "Regen",
        "Lighthouse",
        "Defense"
    };

    int[] skillLevels =
    {
        0,              // Strength
        0,              // Agility
        0,              // Vitality
        0,              // Faith
        0,              // Luck
        0,              // Vision
        0,              // Regen
        0,              // Lighthouse
        0               // Defense
    };

    int[] skillMaxLevels =
    {
        10,             // Strength
        10,             // Agility
        10,             // Vitality
        10,             // Faith
        10,             // Luck
        5,             // Vision
        3,             // Regen
        5,             // Lighthouse
        3              // Defense
    };

    List<int[]> skillPrices = new List<int[]>
    {
        new int[] { 10, 30, 50, 75, 100, 130, 180, 200, 400, 500  },  // Strength
        new int[] { 10, 30, 50, 75, 100, 130, 180, 200, 400, 500  },  // Agility
        new int[] { 10, 30, 50, 75, 100, 130, 180, 200, 400, 500  },  // Vitality
        new int[] { 10, 30, 50, 75, 100, 130, 180, 200, 400, 500  },  // Faitih
        new int[] { 10, 30, 50, 75, 100, 130, 180, 200, 400, 500  },  // Luck
        new int[] { 50, 120, 200, 300, 500 },  // Vision
        new int[] { 200, 500, 1000  },  // Regen
        new int[] { 100, 300, 500, 800, 1000  },  // Lighthouse
        new int[] { 200, 500, 1000  }  // Defense
    };

    int getCurrentLevel (ESkill skill)
    {
        return skillLevels[(int)skill];
    }

    int getMaxLevel(ESkill skill)
    {
        return skillMaxLevels[(int)skill];
    }

    public void increaseLevel(ESkill skill)
    {
        GameManager gameManager = GameManager._instance;
        skillLevels[(int)skill]++;

        switch (skill)
        {
            case ESkill.Strength:
                gameManager.characterStats.SetStatValue(getSkillName(skill), skillLevels[(int)skill]);
                if(isMaxxed(skill))
                {
                    gameManager.playerController.toggleWeapon();
                }
                // increase damage
                break;
            case ESkill.Agility:
                gameManager.characterStats.SetStatValue(getSkillName(skill), skillLevels[(int)skill]);
                break;
            case ESkill.Vitality:
                gameManager.characterStats.SetStatValue(getSkillName(skill), skillLevels[(int)skill]);
                gameManager.characterStats.increaseMaxHealth();
                if (isMaxxed(skill))
                {
                    gameManager.playerController.toggleArmor();
                }
                break;
            case ESkill.Faith:
                gameManager.characterStats.SetStatValue(getSkillName(skill), skillLevels[(int)skill]);
                // increase critical damage chance
                break;
            case ESkill.Luck:
                gameManager.characterStats.SetStatValue(getSkillName(skill), skillLevels[(int)skill]);
                // increase dna drop
                break;
            case ESkill.Vision:
                gameManager.characterStats.SetStatValue(getSkillName(skill), skillLevels[(int)skill]);
                // increase vision range
                if (isMaxxed(skill))
                {
                    gameManager.playerController.toggleGlasses();
                }
                break;
            case ESkill.Regen:
                gameManager.monolith.increaseRegenRadius();
                break;
            case ESkill.Lighthouse:
                // decrease fog of war
                break;
            case ESkill.Defense:
                // attack random enemies in a range - turret
                break;
            default:
                break;
        }
    }
    
    public int getPrice(ESkill skill)
    {
        return skillPrices[(int)skill][getCurrentLevel(skill)];
    }

    public bool isMaxxed(ESkill skill)
    {
        return getCurrentLevel(skill) == getMaxLevel(skill);
    }

    public string getCurrentLevelString(ESkill skill)
    {
        return "Level: " + getCurrentLevel(skill) + " / " + getMaxLevel(skill);
    }

    public string getPriceString(ESkill skill)
    {
        if (getCurrentLevel(skill) == getMaxLevel(skill))
        {
            return "Max Level";
        }
        return "Cost: " + getPrice(skill) + " DNA";
    }

    public string getSkillName(ESkill skill)
    {
        return skillNames[(int)skill];
    }
    
}
