using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wave_System : MonoBehaviour
{
    public GameObject spawnObject;
    public float maxX;
    public float maxY;
    public float minX;
    public float minY;

    public float spawnTime;
    public float incrementation;
    public float waveTime;
    public float pauseTime;

    private float currentTime;
    private float currentSpawnTime = 0;
    private int wave = 1;
    private bool status = false; // 0 - wait time; 1 - wave time \

    private void Start()
    {
        currentTime = pauseTime - 5;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        if (status)
        {
            if (currentTime >= waveTime)
            {
                status = !status;
                currentTime = 0;
                currentSpawnTime = 0;
                wave++;
                spawnTime -= wave * incrementation;
            }
            else
            {
                currentSpawnTime += Time.deltaTime;
                if (currentSpawnTime >= spawnTime)
                {
                    Spawn.SpawnObject(minX, minY, maxX, maxY, spawnObject);
                    currentSpawnTime = 0;
                }
            }
        }
        else
        {
            if (currentTime >= pauseTime)
            {
                status = !status;
                currentTime = 0;
            }
        }

        // Press . for current time
        if (Input.GetKeyDown("."))
        {
            Debug.Log(currentTime);
        }
    }
}
