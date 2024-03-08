using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public SkillTreeUIScript skillTreeUI;
    public DNAPanel dnaPanel;
    public PauseUI pauseUI;
    public EndGameUI endGameUI;

    // Start is called before the first frame update
    void Start()
    {
        skillTreeUI.gameObject.SetActive(false);
        pauseUI.gameObject.SetActive(false);
        endGameUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (skillTreeUI.gameObject.activeSelf)
                skillTreeUI.ToggleSkillTreeUI();
            else
                pauseUI.TogglePause();
        }
    }

    public void ToggleSkillTreeUIScript()
    {
        skillTreeUI.ToggleSkillTreeUI();
    }

    public void ToggleEndGameUI(EndGameUI.EndGameType endGameType)
    {
        endGameUI.ToggleEndGameUI(endGameType);
        Time.timeScale = 0;
        GameManager._instance.playerController.toggleMovement();
        Cursor.visible = true;
    }
}
