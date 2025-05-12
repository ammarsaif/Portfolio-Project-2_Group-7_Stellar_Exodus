using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhirlpoolAnticlockwise : MonoBehaviour
{
    public float rotateSpeed; // Rotation speed of the whirlpool
    public bool isClockwise;  // Set true for clockwise, false for anticlockwise
    public float moveSpeed = 2f; // Speed at which the player moves out of the whirlpool

    void Update()
    {
        // Rotate the whirlpool based on direction
        float direction = isClockwise ? -1f : 1f;
        transform.Rotate(Vector3.forward, direction * rotateSpeed * Time.deltaTime);
    }

    // Detect when the player stays in the whirlpool
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                // Calculate the direction to move the player
                Vector2 playerPosition = collision.transform.position;
                Vector2 whirlpoolPosition = transform.position;
                Vector2 moveDirection = isClockwise ? Vector2.left : Vector2.right;
                Vector2 exitDirection = (playerPosition - whirlpoolPosition).normalized;

                // Move the player out of the whirlpool smoothly
                playerRb.velocity = exitDirection * moveSpeed;
            }
        }
    }

    // Stop moving the player when it exits the whirlpool
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                // Restore player control by resetting velocity
                playerRb.velocity = Vector2.zero;
            }
        }
    }
}
