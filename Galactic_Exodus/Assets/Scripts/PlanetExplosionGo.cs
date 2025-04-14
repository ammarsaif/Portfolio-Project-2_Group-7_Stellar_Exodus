using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetExplosionGo : MonoBehaviour
{
    public GameObject explosionEffect;         // Assign explosion prefab in Inspector
    public AudioClip AsteroidExplosionSound;   // Assign explosion sound in Inspector

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet")) // If hit by a bullet
        {
            Explode();

            Destroy(other.gameObject); // Destroy the bullet
        }
    }

    void Explode()
    {
        // Spawn explosion effect
        GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        explosion.transform.SetParent(null); // Detach from planet

        // Play explosion sound at planet's position
        if (AsteroidExplosionSound != null)
        {
            AudioSource.PlayClipAtPoint(AsteroidExplosionSound, transform.position);
        }
        else
        {
            Debug.LogWarning("Explosion sound not assigned in Inspector.");
        }

        // Destroy the planet
        Destroy(gameObject);

        // Destroy explosion effect after 0.5 seconds
        Destroy(explosion, 0.5f);
    }
}
