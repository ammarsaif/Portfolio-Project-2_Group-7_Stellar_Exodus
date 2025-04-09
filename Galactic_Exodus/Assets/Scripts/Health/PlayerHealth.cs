using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int currentHealth = 100;

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            // Handle spaceship destruction, like triggering explosion, game over, etc.
            Destroy(gameObject);  // Destroy spaceship when health reaches 0
        }
    }
}