using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Banana_Spawn : MonoBehaviour
{
    public GameObject spawnObject;
    public float maxX = 380;
    public float maxZ = 380;
    public float minX = 140;
    public float minZ = 90;

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
                Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), 1.5f, Random.Range(minZ, maxZ));
                GameObject.Instantiate(spawnObject, spawnPosition, spawnObject.transform.rotation);
            }
            spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
            currentTime = 0;
        }
    }
}
