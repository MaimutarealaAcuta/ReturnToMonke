using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public SkillTreeUIScript skillTreeUI;
    
    // Start is called before the first frame update
    void Start()
    {
        skillTreeUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleSkillTreeUIScript()
    {
        skillTreeUI.ToggleSkillTreeUI();
    }
}
