using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{


    public Spawner spawnerData;  // Assign in inspector
    private GameObject player;
    private int currentID = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (spawnerData == null || player == null || currentID >= spawnerData.yPositions.Length)
            return;

        // Check if player has passed the next Y trigger point (moving upward)
        if (player.transform.position.y > spawnerData.yPositions[currentID])
        {
            // Verify we have a corresponding enemy prefab
            if (currentID < spawnerData.enemies.Length && spawnerData.enemies[currentID] != null)
            {
                Debug.Log("Trigger passed — spawning enemies.");
                SpawnEnemyGroup(currentID);
                currentID++; // Move to next Y level
            }
            else
            {
                Debug.LogWarning("Missing or null enemy prefab at currentID!");
            }
        }
    }

    void SpawnEnemyGroup(int spawnIndex)
    {
        Debug.Log($"SpawnEnemyGroup called for index {spawnIndex}");

        for (int i = 0; i < 3; i++) // Spawn 3 enemies
        {
            float randomX = Random.Range(-6f, 6f);
            // Use different Y spawn offsets for each prefab (above player)
            float spawnYOffset = (spawnIndex == 0) ? 2f : 3f; // Adjust spawn distance above the player
            Vector3 spawnPos = new Vector3(randomX, player.transform.position.y + spawnYOffset, 0);

            Instantiate(spawnerData.enemies[spawnIndex], spawnPos, Quaternion.identity);
        }

        Debug.Log($"Spawned enemies at Y trigger: {spawnerData.yPositions[spawnIndex]}");
    }



    /*
    void Update()
    {
        if (spawnerData == null || player == null || currentID >= spawnerData.yPositions.Length)
            return;

        // If player moves downward past the next Y trigger point
        if (player.transform.position.y > spawnerData.yPositions[currentID])
        {
            GameObject enemyPrefab = spawnerData.enemies[currentID];

            // Spawn multiple enemies at random X positions
            for (int i = 0; i < 3; i++) // number of enemies per spawn
            {
                float randomX = Random.Range(-5f, 5f); // horizontal spread
                Vector3 spawnPos = new Vector3(randomX, player.transform.position.y + 3f, 0); // spawn below player
                Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            }

            Debug.Log($"Spawned enemies at Y = {player.transform.position.y}");

            currentID++; // move to next Y level
        }
    }

    */
}
