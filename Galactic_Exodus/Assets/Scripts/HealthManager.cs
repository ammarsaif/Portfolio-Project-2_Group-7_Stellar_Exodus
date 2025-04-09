using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance; // Singleton instance
    
    public Image healthBar; // Reference to the UI health bar image
    private float currentHealth = 1f; // Full health (1 = 100%)
    public float damageAmount = 0.2f; // Damage per hit
    public float healAmount = 0.2f; // Amount of health to increase
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void TakeDamage()
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, 1); // Prevent negative values

        if (healthBar != null)
        {
            healthBar.fillAmount = currentHealth;
        }

        if (currentHealth <= 0)
        {
            PlayerDied();
        }
        else
        {
            // Temporarily disable BoxCollider2D for 1 second
            NewBehaviourScript.Instance.DisableColliderTemporarily();
        }
    }

    private void PlayerDied()
    {
        Debug.Log("Player Destroyed");
        NewBehaviourScript.Instance.HandlePlayerDestruction();
    }

    public void SetHealthToZero()
    {
        currentHealth = 0;

        if (healthBar != null)
        {
            healthBar.fillAmount = 0;
        }

        PlayerDied();
    }

    // New function to increase health
    public void IncreaseHealth()
    {
        
        
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, 1); // Ensure health doesn't exceed 100%

        if (healthBar != null)
        {
            healthBar.fillAmount = currentHealth;
        }
        
    }
    
}
