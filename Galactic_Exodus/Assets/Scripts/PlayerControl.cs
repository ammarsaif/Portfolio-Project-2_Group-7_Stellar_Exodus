using System;
using System.Collections;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public static NewBehaviourScript Instance; // Singleton instance

    public GameObject PlayerBulletFire;
    public GameObject BulletPosition;
    public GameObject explosionPrefab; // Reference to the explosion prefab
    public AudioClip gunFireSound;
    public AudioClip TakingDamageSound;
    public AudioClip GainingHealthSound;
    public AudioClip PlayerDestructionSound;
    public float speed = 5f;
    public float autoMoveSpeed = 2f; // Speed for automatic Y movement

    private Animator animator;
    private BoxCollider2D boxCollider;
    public Animator asteriodsplash;
    public Animator healthsplash;
    public Animator damagesplash;

    public float defaultYOffsetFromBottom = 1f;
    public float returnToDefaultSpeed = 2f;

    public bool autoMoveEnabled = true; // auto move in y direction

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

    void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        // Fire bullet when spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(PlayerBulletFire, BulletPosition.transform.position, Quaternion.identity);

            // Play gun sound at bullet position
            if (gunFireSound != null)
            {
                AudioSource.PlayClipAtPoint(gunFireSound, BulletPosition.transform.position);
            }
            else
            {
                Debug.LogWarning("Gun fire sound not assigned!");
            }
        }

        float x = Input.GetAxisRaw("Horizontal"); // Left & Right movement
        float y = Input.GetAxisRaw("Vertical");   // Up & Down movement
        Vector2 direction = new Vector2(x, y).normalized; // Allow full movement control

        Move(direction);
    }

    void Move(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        max.x -= 0.225f;
        min.x += 0.225f;
        max.y -= 0.225f; // Add vertical limits
        min.y += 0.225f;

        Vector2 pos = transform.position;
        pos.x += direction.x * speed * Time.deltaTime; // X movement
                                                       //pos.y += ((direction.y * speed) + (autoMoveEnabled ? autoMoveSpeed : 0f)) * Time.deltaTime; // Y movement

        if (direction.y != 0)
        {
            // If player presses Up/Down
            pos.y += direction.y * speed * Time.deltaTime;
        }
        else
        {
            // If no key is pressed, gently return to default bottom position
            float targetY = min.y + defaultYOffsetFromBottom;
            pos.y = Mathf.MoveTowards(pos.y, targetY, returnToDefaultSpeed * Time.deltaTime);
        }

        pos.x = Mathf.Clamp(pos.x, min.x, max.x); // Clamp X
        pos.y = Mathf.Clamp(pos.y, min.y, max.y); // Clamp Y

        transform.position = pos;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            HealthManager.Instance.TakeDamage();
            if (asteriodsplash != null)
            {
                asteriodsplash.SetBool("Red", true);

                if (TakingDamageSound != null)
                {
                    AudioSource.PlayClipAtPoint(TakingDamageSound, transform.position);
                }
                Invoke("setfalse", 0.41f); // Assuming 'IsAsteroidHit' is the bool parameter
            }

        }

        if (collision.gameObject.CompareTag("HealthBar"))
        {
            HealthManager.Instance.IncreaseHealth();
            healthsplash.SetBool("Green", true);
            if (GainingHealthSound != null)
            {
                AudioSource.PlayClipAtPoint(GainingHealthSound, transform.position);
            }
            Invoke("stopgreen", 0.41f);

            // Destroy the HealthBar object
            Destroy(collision.gameObject);
        }
    }
    public void stopgreen()
    {
        healthsplash.SetBool("Green", false);
    }
    public void setfalse()
    {
        asteriodsplash.SetBool("Red", false);
    }


    public void DisableColliderTemporarily()
    {
        StartCoroutine(DisableColliderCoroutine());
    }

    private IEnumerator DisableColliderCoroutine()
    {
        if (boxCollider != null)
        {
            boxCollider.enabled = false;
            yield return new WaitForSeconds(1f);
            boxCollider.enabled = true;
        }
    }

    public void HandlePlayerDestruction()
    {
        if (PlayerDestructionSound != null)
        {
            AudioSource.PlayClipAtPoint(PlayerDestructionSound, transform.position);
        }
        GameManager.instance.gameover();
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    public void destrcution()
    {
        damagesplash.SetBool("Yellow", true);
    }
    public void stopdestruction()
    {
        Invoke("stopred", 0.41f);
    }
    public void stopred()
    {
        damagesplash.SetBool("Yellow", false);
    }
}
