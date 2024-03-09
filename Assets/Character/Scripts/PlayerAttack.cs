using System;
using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private float attackCooldown = .5f;
    [SerializeField]
    private float strongAttackCooldown = 1f;
    [SerializeField]
    private int critMultiplier = 2;
    private float lastAttackTime = -Mathf.Infinity;

    [SerializeField]
    private AttackArea attackArea;

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
        if (Input.GetMouseButtonDown(0) && Time.time - lastAttackTime >= attackCooldown)
        {
            animator.SetTrigger("attack");
            StartCoroutine("Hit", false);

            lastAttackTime = Time.time;
        }
        else if (Input.GetMouseButtonDown(1) && Time.time - lastAttackTime >= strongAttackCooldown)
        {
            animator.SetTrigger("strongAttack");
            StartCoroutine("Hit", true);

            lastAttackTime = Time.time;
        }
    }

    private IEnumerator Hit(bool strong)
    {
        foreach (var attackAreaDamageable in attackArea.Damageables)
        {
            int effectiveDamage = ComputeDamage();
            attackAreaDamageable.Damage(effectiveDamage * (strong ? 2 : 1));
        }

        yield return new WaitForSeconds(strong ? strongAttackCooldown : attackCooldown);
    }

    private int ComputeDamage()
    {
        int damage = GameManager._instance.characterStats.GetStatValue("Strength");
        float criticalChance = GameManager._instance.characterStats.GetStatValue("Faith");
        float randomValue = UnityEngine.Random.value;

        int critDamange = randomValue <= (criticalChance / 10f) ? critMultiplier : 1;

        return damage * critDamange;
    }
}
