using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnContact : MonoBehaviour
{
    public int damageAmount = 25;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerShip"))
        {
            Health health = other.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damageAmount);
            }
        }
    }
}
