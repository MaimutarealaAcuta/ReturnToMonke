using System;
using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private float attackCooldown = 2f;
    private float lastAttackTime = -Mathf.Infinity;

    [SerializeField]
    private EnemyAttackArea attackArea;
    [SerializeField]
    private int damage = 1;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        CheckForAttack();
    }

    private void CheckForAttack()
    {
        if (attackArea.inAttakingArea && Time.time - lastAttackTime >= attackCooldown)
        {
            animator.SetTrigger("attack");

            lastAttackTime = Time.time;
        }
    }

    private void Hit()
    {
        foreach (var attackAreaDamageable in attackArea.Damageables)
        {
            int effectiveDamage = ComputeDamage();
            attackAreaDamageable.Damage(effectiveDamage);
        }
    }

    private int ComputeDamage()
    {
        int currentWave = GameManager._instance.waveSystem.getCurrentWave();
        return damage + currentWave;
    }
}
