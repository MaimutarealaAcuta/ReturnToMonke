using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTreeUIScript : MonoBehaviour
{
    SkillTree skillTree;

    // Start is called before the first frame update
    void Start()
    {
        skillTree = GameManager._instance.skillTree;
    }
    
    public bool buySkill(SkillTree.ESkill skill, TMPro.TMP_Text levelText, TMPro.TMP_Text costText)
    {
        if (!GameManager._instance.dnaScript.trySpend(skillTree.getPrice(skill))) return false;
        
        skillTree.increaseLevel(skill);
        levelText.SetText(skillTree.getCurrentLevelString(skill).ToString());
        costText.SetText(skillTree.getPriceString(skill).ToString());

        return skillTree.isMaxxed(skill);
    }

    public void ToggleSkillTreeUI()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        GameManager._instance.playerController.toggleMovement();

        if (gameObject.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
        }
    }
}
