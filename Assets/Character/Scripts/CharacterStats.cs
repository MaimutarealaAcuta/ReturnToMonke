using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    private int maxHealth = 100;
    [SerializeField]
    private int currentHealth;

    [SerializeField]
    private int defaultStrenght;
    [SerializeField]
    private int defaultAgility;
    [SerializeField]
    private int defaultVitality;
    [SerializeField]
    private int defaultFaith;
    [SerializeField]
    private int defaultLuck;
    [SerializeField]
    private int defaultVision;

    [SerializeField]
    Dictionary<string, Stat> stats = new Dictionary<string, Stat>();

    private void Awake()
    {
        currentHealth = maxHealth;

        stats.Add("strenght", new Stat(defaultStrenght));
        stats.Add("agility", new Stat(defaultAgility));
        stats.Add("vitality", new Stat(defaultVitality));
        stats.Add("faith", new Stat(defaultFaith));
        stats.Add("luck", new Stat(defaultLuck));
        stats.Add("vision", new Stat(defaultVision));
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.T))
        {
            TakeDamange(10);
        }
        if (Input.GetKeyUp(KeyCode.H))
        {
            Heal(10);
        }
    }

    public void TakeDamange(int damange)
    {
        currentHealth -= damange;
        Debug.Log(transform.name + " takes " + damange + " dmg.");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int healAmount)
    {
        if (currentHealth + healAmount > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += healAmount;
        }
        Debug.Log(transform.name + " heals for " + healAmount);
    }

    private void Die()
    {
        throw new NotImplementedException();
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
}
