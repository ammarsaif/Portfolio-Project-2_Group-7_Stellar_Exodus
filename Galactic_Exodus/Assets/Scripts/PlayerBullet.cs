using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 7f;
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get bullet's current position
        Vector2 position = transform.position;

        // Move the bullet upwards
        position.y += speed * Time.deltaTime;

        // Update the bullet's position
        transform.position = position;

        // top-right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

        // bullet destroyed when outside the screen
        if (transform.position.y > max.y) {
            Destroy(gameObject);
        }
        
    }
}
