using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetExplosionGo : MonoBehaviour
{
   public GameObject explosionEffect; // Assign this in the Inspector

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
        // Spawn explosion effect and detach it from the planet
        GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        explosion.transform.SetParent(null); // Detach from planet

        // Destroy the planet immediately
        Destroy(gameObject);

        // Destroy the explosion effect after 0.5 seconds
        Destroy(explosion, 0.5f);
    }
}
