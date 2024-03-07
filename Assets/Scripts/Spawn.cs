using UnityEngine;

public class Spawn : MonoBehaviour
{
    public static void SpawnObject(float minX, float minY, float maxX, float maxY, GameObject spawnObject)
    {
        Vector3 pos;
        float side = Random.Range(0f, 100f);

        float x = Random.Range(0, maxX);
        float y = maxY;
        if (x > minX)
        {
            y = Random.Range(0, maxY);
        }
        else
        {
            y = Random.Range(minY, maxY);
        }

        if (side <= 25)
        {
            // Cadran I
            
            pos = new(x, 1, y);
        } else if (side <= 50)
        {
            // Cadran II
            pos = new(-x, 1, y);
        } else if (side <= 75)
        {
            // Cadran III
            pos = new(-x, 1, -y);
        } else
        {
            // Cadran IV
            pos = new(x, 1, -y);
        }

        Instantiate(spawnObject, pos, spawnObject.transform.rotation);
    }
       
}
