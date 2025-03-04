using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMover : MonoBehaviour
{
    public float speed = 0.5f; // Adjust speed to move slowly

    void Update()
    {
        // Move the planet downward
        transform.position += Vector3.down * speed * Time.deltaTime;

        // Destroy the planet when it moves out of the screen
        if (transform.position.y < -6f) // Adjust this value based on your game view
        {
            Destroy(gameObject);
        }
    }
}

