using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour, IDamageable
{
    public int hp;
    public float speed;
    public float distanceTarget;
    public float rotationSpeedDegree;
    public float attackRange;

    [SerializeField]
    private EnemyAttackArea attackArea;

    [SerializeField]
    private int DNAdrop = 1;

    private Vector3 target, monolith;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        hp += GameManager._instance.waveSystem.getCurrentWave();
        monolith = GameObject.FindGameObjectWithTag("Monolith").transform.position;
    }

    private void FixedUpdate()
    {
        float distEnemyPlayer = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
        float distEnemyMonolith = Vector3.Distance(transform.position, monolith);
        if (distEnemyPlayer <= distanceTarget && distEnemyMonolith > attackRange)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform.position;
        }
        else
        {
            target = monolith;
        }

        if (!attackArea.inAttakingArea)
        {
            Vector3 direction = getDirection(target);
            Quaternion rot_dir = Quaternion.LookRotation(direction, Vector3.up);
            rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
            Quaternion rot = Quaternion.RotateTowards(rb.rotation, rot_dir, rotationSpeedDegree * Time.fixedDeltaTime);
            rb.MoveRotation(rot);
        }
        
        if (hp <= 0)
            death();
    }

    private Vector3 getDirection(Vector3 target)
    {
        Vector3 direction = (target - transform.position);
        direction.y = 0;
        return direction.normalized;
    }

    private void death()
    {
        GameManager._instance.spawnSystem.removeEnemy(this.gameObject);
        GameManager._instance.playerController.gameObject.GetComponentInChildren<AttackArea>().removeEnemy(this);
        GameManager._instance.metrics.AddEnemyKilled();

        GameObject helix = Instantiate(GameManager._instance.helixPrefab,
                                       transform.position + new Vector3(0, 1.5f, 0),
                                       new Quaternion(90, 0, 0, 0));

        helix.GetComponent<HelixScript>().setDNAvalue(DNAdrop);
        Destroy(gameObject);
    }

    public void Damage(int damageAmount)
    {
        hp -= damageAmount;        
    }
}
