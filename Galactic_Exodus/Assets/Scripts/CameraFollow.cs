using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    public float smoothSpeed = 1f;  // Speed of camera movement

    private float initialX; // Store the initial X position of the camera

    void Start()
    {
        if (player != null)
        {
            initialX = transform.position.x;  // Keep the X position fixed
        }
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Follow only the Y position of the player
            Vector3 targetPosition = new Vector3(initialX, player.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
    }
}
