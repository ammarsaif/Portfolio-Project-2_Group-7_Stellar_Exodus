using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject[] asteroidPrefabs; // Different asteroid types
    public float spawnRate = 0.1f; // Spawn every 0.2 seconds
    public int asteroidsPerSpawn = 5; // Spawn 5 asteroids at a time
    private float minX, maxX, minY, maxY; // Screen limits

    void Start()
    {
        // Get screen boundaries for spawning
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        minX = min.x;
        maxX = max.x;
        minY = max.y + 2f; // Spawning slightly above the screen
        maxY = max.y + 3f; // Randomized Y position range

        // Start spawning asteroids
        StartCoroutine(SpawnAsteroids());
    }

    IEnumerator SpawnAsteroids()
    {
        while (true) // Infinite loop for continuous spawning
        {
            for (int i = 0; i < asteroidsPerSpawn; i++)
            {
                SpawnAsteroid();
            }
            yield return new WaitForSeconds(spawnRate); // Wait before next spawn
        }
    }

    void SpawnAsteroid()
    {
        if (asteroidPrefabs.Length == 0) return;

        int randomIndex = Random.Range(0, asteroidPrefabs.Length);
        GameObject asteroid = Instantiate(asteroidPrefabs[randomIndex]);

        // Randomize spawn position in both X and Y
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY); // Different Y positions

        asteroid.transform.position = new Vector2(randomX, randomY);
    }
}
