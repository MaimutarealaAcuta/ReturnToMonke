using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 40f;
    public float attackRate = 0.5f; // Attacks per second
    public float fireHeightOffset = 5f; // Height from which projectiles are fired

    private float attackCooldown = 0f;
    private List<GameObject> enemiesInRange = new List<GameObject>();


    private void Update()
    {
        var defenceLevel = GameManager._instance.skillTree.getCurrentLevel(SkillTree.ESkill.Defense);
        
        if (defenceLevel > 0)
        {
            attackCooldown -= Time.deltaTime;

            if (enemiesInRange.Count > 0 && attackCooldown <= 0f)
            {
                AimAndShoot(enemiesInRange[0]);
                attackCooldown = 1f / GetEffectiveAttackRate(defenceLevel);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemiesInRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemiesInRange.Remove(other.gameObject);
        }
    }

    private void AimAndShoot(GameObject target)
    {
        Vector3 firePosition = transform.position + Vector3.up * fireHeightOffset;
        Vector3 direction = (target.transform.position - firePosition).normalized;
        GameObject projectile = Instantiate(projectilePrefab, firePosition, Quaternion.LookRotation(direction));
        projectile.GetComponent<Rigidbody>().velocity = direction * projectileSpeed;
    }

    private float GetEffectiveAttackRate(int defenceLevel)
    {
        float effectiveAttackRate =  attackRate * (defenceLevel + 1);

        return effectiveAttackRate;
    }
}
