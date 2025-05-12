using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetExplosionGo : MonoBehaviour
{
    public GameObject explosionEffect;         // Assign explosion prefab in Inspector
    public AudioClip AsteroidExplosionSound;   // Assign explosion sound in Inspector
    public float destroyTimer;
    public float durationToDestroy;



    private void Update()
    {
        if (destroyTimer < durationToDestroy)
        {
            destroyTimer += Time.deltaTime;
        }
        else
        {
            Explode();
        }
    }


    void Explode()
    {
        // Disable the SpriteRenderer immediately to hide the planet
        GetComponent<SpriteRenderer>().enabled = false;
        GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(explosion, 2f); // Destroy explosion after 1 second
        // Play explosion sound
        if (AsteroidExplosionSound != null)
        {
            AudioSource.PlayClipAtPoint(AsteroidExplosionSound, transform.position);
        }

        // Destroy the entire GameObject after delay
        Destroy(gameObject, 3f);
    }


}