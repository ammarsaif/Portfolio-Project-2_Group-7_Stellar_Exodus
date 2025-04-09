using UnityEngine;
using UnityEngine.UI;

public class CountManager : MonoBehaviour
{
    public static CountManager instance;
    private int destroyedAsteroids = 0;
    
    public Image fillImage; // Assign this in the Inspector
    public float fillIncreasePerAsteroid = 0.2f; // Now public, editable in Inspector
    private float fillAmount = 0f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AsteroidDestroyed()
    {
        destroyedAsteroids++;
        
        // Increase fill by the public value (clamped between 0 and 1)
        fillAmount = Mathf.Clamp(fillAmount + fillIncreasePerAsteroid, 0f, 1f);
        
        if (fillImage != null)
        {
            fillImage.fillAmount = fillAmount;
        }
     if (fillAmount >= 1f)
    {
        GameManager.instance.Levelcompleted();
    }
    }
}
