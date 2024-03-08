using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using static UnityEditor.PlayerSettings;

public class AI : MonoBehaviour
{
    public int hp;
    public float speed;
    public float distanceTarget;
    public float rotationSpeedDegree;
    public float attackRange;
    public int damage;

    private Vector3 target;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float distEnemyPlayer = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
        float distEnemyMonolith = Vector3.Distance(transform.position, Vector3.zero);
        if (distEnemyPlayer <= distanceTarget && distEnemyMonolith > attackRange)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform.position;
        }
        else
        {
            target = Vector3.zero;
        }

        Vector3 direction = getDirection(target);
        Quaternion rot_dir = Quaternion.LookRotation(direction, Vector3.up);
        rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
        Quaternion rot = Quaternion.RotateTowards(rb.rotation, rot_dir, rotationSpeedDegree * Time.fixedDeltaTime);
        rb.MoveRotation(rot);
    }

    private Vector3 getDirection(Vector3 target)
    {
        Vector3 direction = (target - transform.position);
        direction.y = 0;
        return direction.normalized;
    }

    public void setHp(int hp)
    {
        this.hp = hp;
    }

    public int getHp()
    {
        return hp;
    }

    private void takeDamage(int value)
    {
        hp -= value;
        if (hp < 0)
            death();
    }

    private void attackPlayer()
    {
        GameManager._instance.characterStats.TakeDamange(damage);
    }

    private void death()
    {
        // Spawn DNA
        Destroy(gameObject);
    }
}
