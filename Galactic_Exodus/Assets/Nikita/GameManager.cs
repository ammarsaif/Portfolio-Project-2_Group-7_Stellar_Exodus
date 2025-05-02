using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject pausepanel;
    public GameObject Levelcompletedpanel;
    public GameObject GameOver;
    private void Awake()
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
    void Start()
    {
        pausepanel.SetActive(false);
        Levelcompletedpanel.SetActive(false);
        GameOver.SetActive(false);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        Time.timeScale=1;
    }

    public void LoadMainMenu()

    {
        Time.timeScale=1;
        SceneManager.LoadScene("MainMenu"); 
    }
    public void pausethegame()
    {
       pausepanel.SetActive(true);
       Time.timeScale=0;
    }
    public void resumethegame()
    {
       pausepanel.SetActive(false);
       Time.timeScale=1;
    }
    public void Levelcompleted()
    {
        Levelcompletedpanel.SetActive(true);
        Time.timeScale=0;
        
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale=1f;
        
    }
    public void gameover()
    {
        GameOver.SetActive(true);
        Time.timeScale=0;
    }

}
