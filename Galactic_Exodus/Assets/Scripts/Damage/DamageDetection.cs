using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDamage : MonoBehaviour
{
    public int damageAmount = 50;  // Set damage value

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object is tagged as "PlayerShip" (spaceship)
        if (other.CompareTag("PlayerShip"))
        {
            // Access the spaceship's health (assuming the spaceship has a health script)
            Health spaceshipHealth = other.GetComponent<Health>();
            if (spaceshipHealth != null)
            {
                spaceshipHealth.TakeDamage(damageAmount); // Apply damage
            }
        }
    }
}
