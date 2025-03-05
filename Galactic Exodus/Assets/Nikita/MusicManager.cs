using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
            return;
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void ToggleMusic()
    {
        audioSource.mute = !audioSource.mute; 
        PlayerPrefs.SetInt("MusicMuted", audioSource.mute ? 1 : 0); 
        PlayerPrefs.Save();
    }

    void Start()
    {
        audioSource.mute = PlayerPrefs.GetInt("MusicMuted", 0) == 1;
    }
}
