using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNAScript : MonoBehaviour
{
    [SerializeField]
    private int DNA_points = 20;

    private void Start()
    {
        updateUI();
    }

    public bool trySpend(int amount)
    {
        if (DNA_points >= amount)
        {
            DNA_points -= amount;
            updateUI();
            GameManager._instance.metrics.AddSpentDNA(amount);
            return true;
        }
        Debug.Log("Insufficient funds!");
        return false;
    }
    
    public void add(int amount)
    {
        DNA_points += amount;
        updateUI();
    }
    
    public int get()
    {
        return DNA_points;
    }

    private void updateUI()
    {
        GameManager._instance.uiScript.dnaPanel.updateDNA(DNA_points);
    }
}
