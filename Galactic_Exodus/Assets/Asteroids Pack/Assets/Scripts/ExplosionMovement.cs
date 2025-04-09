using UnityEngine;

public class ExplosionMovement : MonoBehaviour
{
    private float speed;

    public void SetSpeed(float asteroidSpeed)
    {
        speed = asteroidSpeed; // Set explosion speed to match asteroid speed
    }

    void Update()
    {
        transform.position += speed * Time.deltaTime * Vector3.down;
    }
}
