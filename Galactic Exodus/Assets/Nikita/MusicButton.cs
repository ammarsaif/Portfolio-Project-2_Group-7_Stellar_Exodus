using UnityEngine;

public class MusicButton : MonoBehaviour
{
    private MusicManager musicManager;

    void Start()
    {
        musicManager = FindObjectOfType<MusicManager>();
    }

    public void ToggleMusic()
    {
        musicManager.ToggleMusic(); 
    }
}
