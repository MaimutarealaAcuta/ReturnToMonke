using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject[] spawnEnemies;
    [SerializeField]
    private GameObject[] spawnStrongEnemies;
    [SerializeField]
    private float strongEnemiesChance = 0.3f;

    [SerializeField]
    private float minSpawningTime = 1.0f;

    [SerializeField]
    private float maxSpawningTime = 10.0f;

    [SerializeField]
    private int maxEnemies = 50;

    public List<GameObject> enemies = new List<GameObject>();

    [SerializeField]
    Bounds spawnBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 0, 100));

    private Coroutine SpawningCoroutine;

    public void StartSpawning(int currentWave)
    {
        maxSpawningTime = Mathf.Clamp(10.0f - currentWave * 0.25f, minSpawningTime, 10.0f);
        SpawningCoroutine = StartCoroutine(SpawnEnemyLogic());
    }

    public void StopSpawning()
    {
        StopCoroutine(SpawningCoroutine);
    }

    public void CleanseEnemies()
    {
        foreach (var enemy in enemies)
        {
            if (enemy != null)
            {
                GameManager._instance.playerController.gameObject.
                        GetComponentInChildren<AttackArea>().removeEnemy(enemy.GetComponent<IDamageable>());
                Destroy(enemy);
            }
        }

        enemies.Clear();
    }

    IEnumerator SpawnEnemyLogic()
    {
        while(true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(Random.Range(minSpawningTime, maxSpawningTime));            
        }        
    }

    private void SpawnEnemy()
    {
        if (enemies.Count >= maxEnemies)
        {
            return;
        }
        
        GameObject randEnemy = spawnEnemies[Random.Range(0, spawnEnemies.Length)];
        GameObject randStrongEnemy = spawnStrongEnemies[Random.Range(0, spawnStrongEnemies.Length)];

        GameObject spawnEnemy = Random.value >= strongEnemiesChance ? randEnemy : randStrongEnemy;

        int spawnSide = Random.Range(0, 4);
        Vector3 spawnPosition = new Vector3(0,0,0);
        
        switch (spawnSide)
        {
            case 0:
                spawnPosition = new Vector3(spawnBounds.min.x, 0, Random.Range(spawnBounds.min.z, spawnBounds.max.z));
                break;
            case 1:
                spawnPosition = new Vector3(spawnBounds.max.x, 0, Random.Range(spawnBounds.min.z, spawnBounds.max.z));
                break;
            case 2:
                spawnPosition = new Vector3(Random.Range(spawnBounds.min.x, spawnBounds.max.x), 0, spawnBounds.min.z);
                break;
            case 3:
                spawnPosition = new Vector3(Random.Range(spawnBounds.min.x, spawnBounds.max.x), 0, spawnBounds.max.z);
                break;
        }

        enemies.Add(Instantiate(spawnEnemy, spawnPosition, spawnEnemy.transform.rotation));
    }

    public void removeEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
    }
}
