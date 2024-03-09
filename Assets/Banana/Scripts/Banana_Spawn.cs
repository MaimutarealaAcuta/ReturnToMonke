using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Banana_Spawn : MonoBehaviour
{
    public GameObject spawnObject;
    public float maxX;
    public float maxY;
    public float minX;
    public float minY;

    public float spawnTimeMin;
    public float spawnTimeMax;

    public int maxItems;
    private int currentItems;

    private float spawnTime;
    private float currentTime;

    private void Start()
    {
        spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= spawnTime)
        {
            currentItems = GameObject.FindGameObjectsWithTag("Item").Length;
            if(currentItems < maxItems)
            {
                Spawn.SpawnObject(minX, minY, maxX, maxY, spawnObject);
            }
            spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
            currentTime = 0;
        }
    }
}
