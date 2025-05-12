using UnityEngine;

public class OrbitalDamageSystem : MonoBehaviour
{
    public AudioClip damageSound;      // Sound to play when the player is hit (optional)

    public float damageAmount = 0.2f;  // Damage dealt per collision

    private HealthManager healthManager;

    void Start()
    {
        // Find the HealthManager in the scene
        healthManager = HealthManager.Instance;
    }

    // This method is called when the player's collider enters the damage zone of the planet or moon
    void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the player collides with the planet or the moon
        if (collider.CompareTag("Player"))
        {
            // Apply damage to the player
            if (healthManager != null)
            {
                healthManager.TakeDamage(); // Call the HealthManager's TakeDamage method
                Debug.Log("Player Health Damaged");
            }

            // Optionally play sound
            PlayDamageSound(collider.transform.position);
        }
    }

    // Function to play damage sound (optional)
    void PlayDamageSound(Vector3 position)
    {
        if (damageSound != null)
        {
            // Play damage sound at the collision point
            AudioSource.PlayClipAtPoint(damageSound, position);
        }
    }
}
