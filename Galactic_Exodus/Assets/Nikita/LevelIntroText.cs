using UnityEngine;
using TMPro;

public class LevelIntroText : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    public float fadeDuration = 1f;
    public float displayDuration = 2f;

    void Start()
    {
        StartCoroutine(ShowLevelText());
    }

    System.Collections.IEnumerator ShowLevelText()
    {
        levelText.canvasRenderer.SetAlpha(0f);

        levelText.CrossFadeAlpha(1f, fadeDuration, false);

        yield return new WaitForSeconds(displayDuration);

        levelText.CrossFadeAlpha(0f, fadeDuration, false);
    }
}
