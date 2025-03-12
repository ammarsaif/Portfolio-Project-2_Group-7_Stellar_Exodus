using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // For restarting the game

public class Asteroid : MonoBehaviour
{
    public GameObject explosionPrefab; // Explosion prefab
    public int maxHitpoints = 3; // Set this in the Inspector for each asteroid
    private int currentHitpoints;
    public float minSpeed = 2f; // Minimum asteroid speed
    public float maxSpeed = 5f; // Maximum asteroid speed
    private float speed;

    private Renderer asteroidRenderer;
    private Material asteroidMaterial;
    private Color originalColor;

    void Start()
    {
        // Assign a random speed for variation
        speed = Random.Range(minSpeed, maxSpeed);

        // Set asteroid HP to its max HP
        currentHitpoints = maxHitpoints;

        // Get the asteroid's renderer and store its original color
        asteroidRenderer = GetComponent<Renderer>();
        if (asteroidRenderer != null)
        {
            asteroidMaterial = asteroidRenderer.material;
            originalColor = asteroidMaterial.color;

            // Enable emission if not already enabled
            asteroidMaterial.EnableKeyword("_EMISSION");
        }
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

    // 2D Collision Detection
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the asteroid was hit by a bullet
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(); // Reduce asteroid HP
            Destroy(collision.gameObject); // Destroy the bullet immediately
        }

        // Check if asteroid collides with the spaceship
        if (collision.gameObject.CompareTag("PlayerShip"))
        {
            DestroyPlayerShip(collision.gameObject); // Handle spaceship destruction
        }
    }

    void TakeDamage()
    {
        currentHitpoints--;

        if (currentHitpoints <= 0)
        {
            // If HP reaches 0, spawn explosion and destroy the asteroid
            SpawnExplosion();
            Destroy(gameObject); // Destroy the asteroid
        }
    }

    void SpawnExplosion()
    {
        if (explosionPrefab != null)
        {
            // Instantiate explosion at asteroid's position
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, 2f); // Destroy the explosion after 2 seconds
        }
    }

    void DestroyPlayerShip(GameObject spaceship)
    {
        // Handle spaceship destruction logic
        Animator playerAnimator = spaceship.GetComponent<Animator>();
        if (playerAnimator != null)
        {
            playerAnimator.SetBool("DIE", true); // Play the death animation
        }

        Destroy(spaceship, 1f); // Destroy the spaceship after 1 second
    }
}
