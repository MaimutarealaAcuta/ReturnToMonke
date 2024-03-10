using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour, IDamageable
{
    private int maxHealth = 100;
    [SerializeField]
    private int currentHealth;

    [SerializeField]
    private int defaultStrenght = 0;
    [SerializeField]
    private int defaultAgility = 0;
    [SerializeField]
    private int defaultVitality = 0;
    [SerializeField]
    private int defaultFaith = 0;
    [SerializeField]
    private int defaultLuck = 0;
    [SerializeField]
    private int defaultVision = 0;

    [SerializeField]
    Dictionary<string, Stat> stats = new Dictionary<string, Stat>();

    [SerializeField]
    private HealthVolume healthVolume;
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        currentHealth = maxHealth;

        stats.Add("Strength", new Stat(defaultStrenght));
        stats.Add("Agility", new Stat(defaultAgility));
        stats.Add("Vitality", new Stat(defaultVitality));
        stats.Add("Faith", new Stat(defaultFaith));
        stats.Add("Luck", new Stat(defaultLuck));
        stats.Add("Vision", new Stat(defaultVision));
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.T))
        {
            Damage(10);
        }
        if (Input.GetKeyUp(KeyCode.H))
        {
            Heal(10);
        }
    }
    
    private void SetCurrentHealth(int health)
    {
        currentHealth = health;
        healthVolume.updateVolume((float)currentHealth / maxHealth);
    }

    public void Damage(int damage)
    {
        audioManager.playSFX(audioManager.hitSoundEnemy);
        SetCurrentHealth(currentHealth - damage);
        Debug.Log(transform.name + " takes " + damage + " dmg.");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int healAmount)
    {
        if (currentHealth + healAmount > maxHealth)
        {
            SetCurrentHealth(maxHealth);
        }
        else
        {
            SetCurrentHealth(currentHealth + healAmount);
        }
        Debug.Log(transform.name + " heals for " + healAmount);
    }

    public void HealPercentage(int percentage)
    {
        int healAmount = (int)(maxHealth * percentage / 100);
        Heal(healAmount);
    }
    public bool IsAtMaxHealth()
    {
        return currentHealth == maxHealth;
    }

    private void Die()
    {
        GameManager._instance.uiScript.ToggleEndGameUI(EndGameUI.EndGameType.Death);
    }

    public int GetStatValue(string key)
    {
        if (stats.ContainsKey(key))
        {
            return stats[key].BaseValue;
        }

        Debug.LogWarning($"Stat with key '{key}' not found.");
        return 0;
    }

    public void SetStatValue(string key, int value)
    {
        if (stats.ContainsKey(key))
        {
            stats[key].BaseValue = value;
        }
        else
        {
            Debug.LogWarning($"Stat with key '{key}' not found.");
            //stats.Add(key, new Stat(value));
        }
    }

    public void increaseMaxHealth()
    {
        int newMaxHealth = (int)(maxHealth * 1.5f);
        float healthPercentage = (float)currentHealth / maxHealth;
        maxHealth = newMaxHealth;
        SetCurrentHealth((int)(maxHealth * healthPercentage));

        transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
    }
}
