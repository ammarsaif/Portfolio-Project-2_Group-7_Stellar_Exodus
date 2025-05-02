using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetExplosionGo : MonoBehaviour
{
    public GameObject explosionEffect;         // Assign explosion prefab in Inspector
    public AudioClip AsteroidExplosionSound;   // Assign explosion sound in Inspector

    void Explode()
    {
        // Disable the SpriteRenderer immediately to hide the planet
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.enabled = false;
        }

        // Disable any Collider to prevent further interactions
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = false;
        }

        // Spawn explosion effect (make sure it's not a child of this object)
        if (explosionEffect != null)
        {
            GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(explosion, 1f); // Destroy explosion after 1 second
        }
        else
        {
            Debug.LogWarning("Explosion effect not assigned in Inspector.");
        }

        // Play explosion sound
        if (AsteroidExplosionSound != null)
        {
            AudioSource.PlayClipAtPoint(AsteroidExplosionSound, transform.position);
        }

        // Destroy the entire GameObject after delay
        Destroy(gameObject, 0.5f);
    }

    /*
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
         Destroy(gameObject, 0.5f);

         // Destroy explosion effect after 0.5 seconds
         Destroy(explosion, 1f);
     }

     */
}
