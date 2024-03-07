using UnityEngine;

public class Monolith : MonoBehaviour, IInteractable
{
    private int health = 100;


    public RegenField regenField;

    public void Update()
    {
        if (health <= 0)
        {
            // trigger end game
        }
    }
    
    public void Interact()
    {
        // trigger skill tree UI
        GameManager._instance.uiScript.ToggleSkillTreeUIScript();
    }

    public void increaseRegenRadius()
    {
        regenField.increaseRegenRadius();
    }
}
