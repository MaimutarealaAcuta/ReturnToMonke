using System.Collections;
using UnityEngine;

public class Monolith : MonoBehaviour, IInteractable, IDamageable
{
    [SerializeField]
    private const int maxHealth = 10000;

    [SerializeField]
    [Range(0, maxHealth)]
    private int health = 10000;

    public RegenField regenField;
    public GameObject runesObj;

    private bool gameOver = false;
    private AudioManager audioManager;

    private bool notifCooldown = false;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void Update()
    {
        if (gameOver) return;
        if (health <= 0)
        {
            GameManager._instance.uiScript.ToggleEndGameUI(EndGameUI.EndGameType.MonolithDeath);
            gameOver = true; 
        }

        updateRunes();
    }
    
    public void Interact()
    {
        // trigger skill tree UI
        GameManager._instance.uiScript.ToggleSkillTreeUIScript();
    }
    
    public void Damage(int damageAmount)
    {
        audioManager.playSFX(audioManager.hitSoundEnemy);
        health -= damageAmount;
        Debug.Log("Monolith took " + damageAmount + " damage. Health: " + health);

        if(!notifCooldown)
            StartCoroutine(notifyAttack());
    }

    IEnumerator notifyAttack()
    {
        notifCooldown = true;
        gameObject.GetComponentInChildren<MonolithBubble>().ShowWaveText("The monolith is under attack!");
        yield return new WaitForSeconds(30);
        notifCooldown = false;
    }

    public void increaseRegenRadius()
    {
        regenField.increaseRegenRadius();
    }

    private void updateRunes()
    {
        Material runesMat = runesObj.GetComponent<Renderer>().material;
        float alpha = (float)health / maxHealth;
        runesMat.color = new Color(runesMat.color.r, runesMat.color.g, runesMat.color.b, alpha);
    }
}
