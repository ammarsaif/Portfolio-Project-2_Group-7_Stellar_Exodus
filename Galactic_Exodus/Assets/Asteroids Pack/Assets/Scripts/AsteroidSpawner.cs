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

        // Use camera's top instead of player position
        Vector2 camTop = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 1f));
        float spawnY = camTop.y + Random.Range(1f, 3f); // 1 to 3 units above the screen

        float randomX = Random.Range(minX, maxX);

        asteroid.transform.position = new Vector2(randomX, spawnY);
    }

    /*
   void SpawnAsteroid()
    {
        if (asteroidPrefabs.Length == 0 || NewBehaviourScript.Instance == null) return;

        int randomIndex = Random.Range(0, asteroidPrefabs.Length);
        GameObject asteroid = Instantiate(asteroidPrefabs[randomIndex]);

        // Get player's current position
        float playerY = NewBehaviourScript.Instance.transform.position.y;

        // Randomize X position within screen width
        float randomX = Random.Range(minX, maxX);

        // Spawn asteroid 3 to 4 units above the player's Y position
        float randomY = playerY + Random.Range(3f, 4f);

        asteroid.transform.position = new Vector2(randomX, randomY);
    }

    */

}
