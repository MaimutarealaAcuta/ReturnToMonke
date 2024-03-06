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

    public static double DEGREE(double radians)
    {
        return radians * 180 / Math.PI;
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        double radians = Math.Atan2(transform.position.z, transform.position.x) + Math.PI;
       
        if(move)
        {
            transform.Translate(speed * (float)Math.Cos(radians) * Time.deltaTime, 0, speed * (float)Math.Sin(radians) * Time.deltaTime);
        }

        if(transform.position.x < 1 && transform.position.z < 1 &&
           transform.position.x > -1 && transform.position.z > -1)
        {
            move = false;
        }

        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
