using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 1; // Amount of damage the projectile will deal

    private void Start()
    {
        Destroy(gameObject, 2f); // Destroy the projectile after 5 seconds if it doesn't hit anything.
    }

    private void OnCollisionEnter(Collision collision)
    {
        AI enemy = collision.gameObject.GetComponent<AI>();

        if (enemy != null)
        {
            var defenceLevel = GameManager._instance.skillTree.getCurrentLevel(SkillTree.ESkill.Defense);
            enemy.hp -= (damage + defenceLevel); // Subtract the damage from the enemy's health
            Destroy(gameObject); // Destroy the projectile on hit
        }
    }
}
