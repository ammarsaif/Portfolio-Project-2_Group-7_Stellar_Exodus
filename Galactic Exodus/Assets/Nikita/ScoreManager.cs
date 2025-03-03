using UnityEngine;
using TMPro; 

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; 
    public float score = 0f; 
    public float scoreRate = 10f; 

    void Update()
    {
        score += scoreRate * Time.deltaTime; 
        scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString(); 
    }
}
