using System.Collections;
using UnityEngine;

public class ExplosionHealthDamage : MonoBehaviour
{
    [Header("Damage Settings")]
    public float damageAmount = 0.2f; // Percentage of health to decrease (0.2 = 20%)

    private HealthManager healthManager;

    void Start()
    {
        healthManager = HealthManager.Instance; // Access Singleton HealthManager
    }

    public void ApplyDamage()
    {
        if (healthManager != null)
        {
            healthManager.TakeDamage(); // Directly call TakeDamage
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Assuming the player has the tag "Player"
        {
            ApplyDamage();
            Debug.Log("Player took damage from explosion");
        }
    }
}
