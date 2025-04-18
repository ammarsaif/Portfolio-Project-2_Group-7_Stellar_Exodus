using System.Collections;
using UnityEngine;

public class StaticSpawner : MonoBehaviour
{
    public GameObject[] staticPrefabs; // Array for two prefabs
    public float minTimer = 0;
    public float maxTimer = 5;
    private float spawnHeight = 5f; // Spawn 5 units above player

    void Start()
    {
        StartCoroutine(SpawnStaticObjects());
    }

    IEnumerator SpawnStaticObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTimer, maxTimer)); // Wait randomly between 0 to 25 seconds
            SpawnObject();
        }
    }


    void SpawnObject()
    {
        if (staticPrefabs.Length == 0 || NewBehaviourScript.Instance == null) return;

        int randomIndex = Random.Range(0, staticPrefabs.Length);
        GameObject spawnedObject = Instantiate(staticPrefabs[randomIndex]);

        // Get player's position
        float playerX = NewBehaviourScript.Instance.transform.position.x;

        // Random X position within 10 units (5 left to 5 right)
        float randomX = playerX + Random.Range(-5f, 5f);

        spawnedObject.transform.position = new Vector2(randomX, NewBehaviourScript.Instance.transform.position.y + spawnHeight);

        // Destroy after 15 seconds
        Destroy(spawnedObject, 15.0f);
    }
}
