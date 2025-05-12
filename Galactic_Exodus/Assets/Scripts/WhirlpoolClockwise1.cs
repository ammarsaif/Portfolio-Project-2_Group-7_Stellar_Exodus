using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhirlpoolClockwise : MonoBehaviour
{
    public float rotateSpeed = 100f; // Rotation speed of the whirlpool
    public float moveSpeed = 2f;     // Speed at which the player moves out of the whirlpool

    void Update()
    {
        // Rotate the whirlpool clockwise (negative Z-axis rotation)
        transform.Rotate(0, 0, -rotateSpeed * Time.deltaTime);
    }

    // Detect when the player stays in the whirlpool
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                // Calculate the direction to move the player to the left
                Vector2 playerPosition = collision.transform.position;
                Vector2 whirlpoolPosition = transform.position;
                Vector2 exitDirection = (playerPosition - whirlpoolPosition).normalized;

                // Smoothly move the player to the left (clockwise effect)
                playerRb.velocity = Vector2.left * moveSpeed;
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
