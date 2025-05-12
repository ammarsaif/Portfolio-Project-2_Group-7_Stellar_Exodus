using System.Collections;
using UnityEngine;

public class BlackholeEffect : MonoBehaviour
{
    public GameObject ExplosionGo;     // Assign explosion prefab in Inspector
    public AudioClip BlackHoleCollisionSound;         // Assign Gun5_1 clip in Inspector

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            StartCoroutine(DestroyShipWithEffect(col.gameObject));
        }
    }

    private IEnumerator DestroyShipWithEffect(GameObject ship)
    {
        // Instantiate explosion
        GameObject explosion = Instantiate(ExplosionGo, ship.transform.position, Quaternion.identity);

        // Play sound at that position
        if (BlackHoleCollisionSound != null)
        {
            AudioSource.PlayClipAtPoint(BlackHoleCollisionSound, ship.transform.position);
        }
        else
        {
            Debug.LogWarning("Gun sound not assigned in Inspector!");
        }

        // Optionally: hide spaceship visuals immediately (optional)
        SpriteRenderer sr = ship.GetComponent<SpriteRenderer>();
        if (sr != null)
            sr.enabled = false;

        // Wait for explosion duration (adjust as needed)
        yield return new WaitForSeconds(1f);

        // Set health to zero
        HealthManager.Instance.SetHealthToZero();

        // Destroy the ship after delay
        Destroy(ship);
    }
}

