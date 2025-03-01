using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
	public GameObject PlayerBulletFire;	
	public GameObject BulletPosition;	

    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		// fire bullet when spacebar is pressed
		if (Input.GetKeyDown(KeyCode.Space)) {
			GameObject bullet = Instantiate(PlayerBulletFire, BulletPosition.transform.position, Quaternion.identity);
			bullet.transform.position = BulletPosition.transform.position;
		}

        float x = Input.GetAxisRaw ("Horizontal"); // the value will be -1, 0, or 1 (for left, no input, and right)
        float y = Input.GetAxisRaw ("Vertical"); // the value will be -1, 0, or 1 (for down, no input, and up)

        // input direction vector

        Vector2 direction = new Vector2 (x, y).normalized;

		// Call Move function
		
		Move(direction);
    }

    void Move(Vector2 direction)
	{
		//find the screen limits to the player's movement (left, right, top and bottom edges of the screen)
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0)); //this is the bottom-left point (corner) of the screen
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1)); //this is the top-right point (corner) of the screen

		max.x = max.x - 0.225f; //subtract the player sprite half width
		min.x = min.x + 0.225f; //add the player sprite half width

		max.y = max.y - 0.285f; //subtract the player sprite half height
		min.y = min.y + 0.285f; //add the player sprite half height

		//Get the player's current position
		Vector2 pos = transform.position;

		//Calculate the new position
		pos += direction * speed * Time.deltaTime;

		//Make sure the new position is outside the screen
		pos.x = Mathf.Clamp (pos.x, min.x, max.x);
		pos.y = Mathf.Clamp (pos.y, min.y, max.y);

		//Update the player's position
		transform.position = pos;
	}

	void OnTriggerEnter2D(Collider2D col) 
	{
		if (col.CompareTag("Asteroid")) 
		{
			Destroy(gameObject);
		}
	}
}
