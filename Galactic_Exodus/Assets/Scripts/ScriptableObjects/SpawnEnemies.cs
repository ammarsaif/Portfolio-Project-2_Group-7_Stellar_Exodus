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

        // If player moves upward past the next Y trigger point
        if (player.transform.position.y > spawnerData.yPositions[currentID])
        {
            GameObject enemyPrefab = spawnerData.enemies[currentID];

            float randomX = Random.Range(-8f, 8f);  // Random X position (left-right)
            float randomY = Random.Range(2f, 5f);   // Random Y position (above player)

            Vector3 spawnPos = new Vector3(randomX, player.transform.position.y + randomY, 0);
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

            /*
            // Spawn multiple enemies at random X and Y positions above the player
            for (int i = 0; i <= 1; i++) // number of enemies per spawn
            {
                float randomX = Random.Range(-8f, 8f);  // Random X position (left-right)
                float randomY = Random.Range(2f, 6f);   // Random Y position (above player)

                Vector3 spawnPos = new Vector3(randomX, player.transform.position.y + randomY, 0);
                Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            }

            */

            Debug.Log($"Spawned enemies at random positions above Y = {player.transform.position.y}");

            currentID++; // move to next Y level
        }
    }
}
