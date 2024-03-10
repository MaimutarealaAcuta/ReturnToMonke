using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public List<IDamageable> Damageables { get; } = new();

    public void OnTriggerEnter(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();

        if (damageable != null)
        {
            Damageables.Add(damageable);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();

        if (damageable != null)
        {
            Damageables.Remove(damageable);
        }
    }

    public void removeEnemy(IDamageable enemy)
    {
        if(Damageables.Contains(enemy))
            Damageables.Remove(enemy);
    }
}
