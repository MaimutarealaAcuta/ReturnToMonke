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

    private bool isStrongAttack = false;
    private AudioManager audioManager;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        CheckForAttack();
    }

    private void CheckForAttack()
    {
        if (!GameManager._instance.playerController.canMove) return;
        
        if (Input.GetMouseButtonDown(0) && Time.time - lastAttackTime >= attackCooldown)
        {
            animator.SetTrigger("attack");
            isStrongAttack = false;

            lastAttackTime = Time.time;
        }
        else if (Input.GetMouseButtonDown(1) && Time.time - lastAttackTime >= strongAttackCooldown)
        {
            animator.SetTrigger("strongAttack");
            isStrongAttack = true;

            lastAttackTime = Time.time;
        }
    }

    private void Hit()
    {
        foreach (var attackAreaDamageable in attackArea.Damageables)
        {
            int effectiveDamage = ComputeDamage();
            attackAreaDamageable.Damage(effectiveDamage * (isStrongAttack ? 2 : 1));
            audioManager.playSFX(audioManager.hitSoundPlayer);
        }
    }

    private int ComputeDamage()
    {
        int strength = GameManager._instance.characterStats.GetStatValue("Strength");
        float criticalChance = GameManager._instance.characterStats.GetStatValue("Faith");
        float randomValue = UnityEngine.Random.value;

        int critDamage = randomValue <= (criticalChance / 10f) ? critMultiplier : 1;

        int damage = (int)((1+strength) * 2.5 * critDamage);

        return damage;
    }

    void ToggleMovementAfterAttack()
    {
        GameManager._instance.playerController.toggleMovement();
    }
}
