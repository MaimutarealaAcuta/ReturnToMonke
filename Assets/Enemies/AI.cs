using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class AI : MonoBehaviour
{
    public float hp;
    public float speed;
    public float distanceTarget;

    private bool move = true;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 direction = (Vector3.zero - transform.position).normalized;
        direction.y = 0;
        if (move)
        {
            rb.isKinematic = false;
            transform.Translate(direction * speed * Time.deltaTime);
        } 
        else
        {
            rb.isKinematic = true;
        }

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Monolith"))
        {
            move = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            AI col = collision.gameObject.GetComponent<AI>();
            if (col != null)
            {
                move = col.move;
            }
        }
    }

    //private void OnCollisionStay(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Monolith"))
    //    {
    //        move = false;
    //    }
    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    if(collision.gameObject.CompareTag("Monolith"))
    //    {
    //        move = true;
    //    }
    //}
}
