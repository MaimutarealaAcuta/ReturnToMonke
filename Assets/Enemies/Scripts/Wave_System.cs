using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wave_System : MonoBehaviour
{
    [SerializeField]
    private GameObject[] spawnEnemies;
    [SerializeField]
    private GameObject[] spawnStrongEnemies;
    [SerializeField]
    private float strongEnemiesChance = 0.3f;
    public float maxX;
    public float maxY;
    public float minX;
    public float minY;

    private float spawnTime;
    public float spawnTimeMin;
    public float spawnTimeMax;
    public float incrementation;
    public float waveTime;
    public float pauseTime;

    private float currentTime;
    private float currentSpawnTime = 0;
    private int wave = 1;
    private bool status = false; // 0 - wait time; 1 - wave time

    private void Start()
    {
        spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        if (status)
        {
            // change wave status
            if (currentTime >= waveTime)
            {
                status = !status;
                currentTime = 0;
                currentSpawnTime = 0;
                wave++;
                spawnTimeMin -= wave * incrementation;
                spawnTimeMax -= wave * incrementation;
                spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
            }
            else
            {
                // spawn enemy
                currentSpawnTime += Time.deltaTime;
                if (currentSpawnTime >= spawnTime)
                {
                    SpawnEnemy();
                    
                    currentSpawnTime = 0;
                    spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
                }
            }
        }
        else
        {
            // waiting time
            if (currentTime >= pauseTime)
            {
                status = !status;
                currentTime = 0;
                currentSpawnTime = 0;
            }
        }
    }

    private void SpawnEnemy()
    {
        GameObject randEnemy = spawnEnemies[Random.Range(0, spawnEnemies.Length)];
        GameObject randStrongEnemy = spawnStrongEnemies[Random.Range(0, spawnStrongEnemies.Length)];

        GameObject spawnEnemie = Random.value >= strongEnemiesChance ? randEnemy : randStrongEnemy;

        Spawn.SpawnObject(minX, minY, maxX, maxY, spawnEnemie);
    }
}
