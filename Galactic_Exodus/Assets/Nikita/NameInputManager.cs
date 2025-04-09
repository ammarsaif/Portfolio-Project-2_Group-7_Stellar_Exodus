using UnityEngine;
using TMPro; // Подключаем TextMeshPro

public class NameInputManager : MonoBehaviour
{
    public GameObject namePanel; // Панель ввода имени
    public TMP_InputField nameInputField; // Используем TMP_InputField

    private const string PlayerNameKey = "PlayerName";

    void Start()
    {
        if (PlayerPrefs.HasKey(PlayerNameKey))
        {
            namePanel.SetActive(false); // Если имя есть, скрываем панель
        }
        else
        {
            namePanel.SetActive(true); // Показываем ввод
        }
    }

    public void SaveName()
    {
        string playerName = nameInputField.text.Trim(); // Берём текст из TMP_InputField

        if (!string.IsNullOrEmpty(playerName))
        {
            PlayerPrefs.SetString(PlayerNameKey, playerName);
            PlayerPrefs.Save();
            namePanel.SetActive(false); // Скрываем после ввода
        }
    }
}
