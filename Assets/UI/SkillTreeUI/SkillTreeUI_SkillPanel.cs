using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTreeUI_SkillPanel : MonoBehaviour
{

    [SerializeField]
    private TMPro.TMP_Text skillName_text;

    [SerializeField]
    private TMPro.TMP_Text level_text;
    
    [SerializeField]
    private TMPro.TMP_Text price_text;
    
    [SerializeField]
    private SkillTree.ESkill skill;
    
    [SerializeField]
    private Button buyButton;

    [SerializeField]
    private Sprite buttonIcon;


    public void Start()
    {
        buyButton.GetComponent<Image>().sprite = buttonIcon;
        skillName_text.SetText(GameManager._instance.skillTree.getSkillName(skill));
        level_text.SetText(GameManager._instance.skillTree.getCurrentLevelString(skill));
        price_text.SetText(GameManager._instance.skillTree.getPriceString(skill));
    }


    public void BuySkill()
    {
        buyButton.enabled = !(GameManager._instance.uiScript.skillTreeUI.buySkill(skill, level_text, price_text));
    }
}
