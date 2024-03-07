using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTreeUIScript : MonoBehaviour
{
    SkillTree skillTree;

    

    [SerializeField]
    private TMPro.TMP_Text regen_level;
    [SerializeField]
    private TMPro.TMP_Text regen_price;

    // Start is called before the first frame update
    void Start()
    {
        skillTree = GameManager._instance.skillTree;
    }

    public void BuyRegen(Button bt)
    {
        buySkill(SkillTree.ESkill.Regen, regen_level, regen_price);
        if (skillTree.isMaxxed(SkillTree.ESkill.Regen))
            bt.interactable = false;

    }

    void buySkill(SkillTree.ESkill skill, TMPro.TMP_Text levelText, TMPro.TMP_Text costText)
    {
        skillTree.increaseLevel(skill);
        levelText.SetText(skillTree.getCurrentLevelString(skill).ToString());
        costText.SetText(skillTree.getCostString(skill).ToString());
        levelText.text = skillTree.getCurrentLevelString(skill).ToString();
        costText.text = skillTree.getCostString(skill).ToString();
    }

    public void ToggleSkillTreeUI()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        GameManager._instance.playerController.toggleMovement();

        if (gameObject.activeSelf)
        {
            //Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            //Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
