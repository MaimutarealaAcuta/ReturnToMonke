using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackArea : MonoBehaviour
{
    public bool inAttakingArea = false;
    public List<IDamageable> Damageables { get; } = new();

    public void OnTriggerEnter(Collider other)
    {
        var damageable = other.gameObject.GetComponent<IDamageable>();

        if (damageable != null && (other.CompareTag("Player") || other.CompareTag("Monolith")))
        {
            inAttakingArea = true;
            Damageables.Add(damageable);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();

        if (damageable != null && (other.CompareTag("Player") || other.CompareTag("Monolith")))
        {
            inAttakingArea = false;
            Damageables.Remove(damageable);
        }
    }
}
