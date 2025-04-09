using UnityEngine;
using TMPro;

public class PlayerName : MonoBehaviour
{
    [SerializeField] private TMP_InputField _input;

    void Start()
    {
        _input.text = PlayerPrefs.GetString("PlayerName", "");
    }

    public void SaveName()
	{
        PlayerPrefs.SetString("PlayerName", _input.text);
    }
}