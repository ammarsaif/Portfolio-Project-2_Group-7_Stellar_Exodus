using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // For restarting the game

public class Asteroid : MonoBehaviour
{
    public GameObject explosionPrefab;
    public int maxHitpoints; // Set this in the Inspector for each asteroid type
    private int currentHitpoints;
    public float minSpeed = 2f; // Minimum asteroid speed
    public float maxSpeed = 5f; // Maximum asteroid speed
    private float speed;

    void Start()
    {
        // Assign a random speed for variation
        speed = Random.Range(minSpeed, maxSpeed);
        currentHitpoints = maxHitpoints;
    }

    void Update()
    {
        // Move the asteroid downward
        transform.position += speed * Time.deltaTime * Vector3.down;

        // Destroy asteroid if it moves out of screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        if (transform.position.y < min.y - 3f) // Extra offset to ensure it's fully gone
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.CompareTag("Bullet")) 
        {
            TakeDamage(); // Reduce HP
            Destroy(col.gameObject); // Destroy bullet
        }
        else if (col.CompareTag("Player")) // 🚀 Destroy player on collision
        {
            Destroy(col.gameObject);
            SpawnExplosion();
        }
    }

    void TakeDamage()
    {
        currentHitpoints--;

        if (currentHitpoints <= 0)
        {
            SpawnExplosion();
            Destroy(gameObject);
        }
    }

    void SpawnExplosion()
    {
        if (explosionPrefab != null)
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // Ensure explosion animation plays
            Animator explosionAnimator = explosion.GetComponent<Animator>();
            if (explosionAnimator != null)
            {
                explosionAnimator.Play("ExplosionAnimation"); // Name must match exactly in Unity
            }

            // Destroy the explosion after animation completes
            Destroy(explosion, 0.5f); // Adjust timing based on animation length
        }
    }
}
