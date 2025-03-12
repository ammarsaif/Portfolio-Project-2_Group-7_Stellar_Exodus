using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackholeEffect : MonoBehaviour
{
    public GameObject ExplosionGo; // 🔹 Make sure this is public so it appears in Inspector

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("PlayerShip")) // Ensure the tag matches the spaceship
        {
            // Instantiate explosion at spaceship position
            Instantiate(ExplosionGo, col.transform.position, Quaternion.identity);

            // Destroy the spaceship immediately
            Destroy(col.gameObject);
        }
    }
}
