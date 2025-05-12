using System.Collections;
using UnityEngine;

public class PlanetExplosion : MonoBehaviour
{
    [Header("Health Settings")]
    public float maxHealth = 100f;
    private float currentHealth;

    [Header("Explosion Settings")]
    public GameObject explosionPrefab;
    public AudioClip AsteroidExplosionSound;   // Explosion sound
    public float destroyTimer = 0f;
    public float durationToDestroy = 3f;

    private HealthManager healthManager;

    void Start()
    {
        currentHealth = maxHealth;
        healthManager = HealthManager.Instance; // Access Singleton HealthManager
    }

    void Update()
    {
        if (destroyTimer > 0)
        {
            destroyTimer += Time.deltaTime;

            if (destroyTimer >= durationToDestroy)
            {
                Explode();
            }
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (healthManager != null)
        {
            healthManager.TakeDamage(); // Use HealthManager's TakeDamage
        }

        if (currentHealth <= 0 && destroyTimer == 0)
        {
            destroyTimer = 0.01f; // Start the destruction timer
        }
    }

    void Explode()
    {
        // Hide the planet sprite
        GetComponent<SpriteRenderer>().enabled = false;

        // Trigger explosion effect
        if (explosionPrefab)
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(explosion, 2f);
        }

        // Play explosion sound
        if (AsteroidExplosionSound)
        {
            AudioSource.PlayClipAtPoint(AsteroidExplosionSound, transform.position);
        }

        // Destroy the planet game object
        Destroy(gameObject, 1f);
    }
}
