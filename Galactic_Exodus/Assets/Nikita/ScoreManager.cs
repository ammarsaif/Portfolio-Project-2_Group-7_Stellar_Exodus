using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // Singleton instance

    public TextMeshProUGUI scoreText; // Reference to the TMP UI text
    public float score = 0f; // Current score

    public int Score { get => (int)score; }

    private void Awake()
    {
        // Singleton pattern to ensure only one instance exists
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

    void Update()
    {
        // Update the score display every frame
        scoreText.text = Mathf.FloorToInt(score).ToString();
    }

    // Function to increment the score by 1
    public void IncrementScore()
    {
        score += 1;
    }
}

