using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public void Damage(int damageAmount)
    {
        Debug.Log("Took " +  damageAmount + " damage");
    }
}
