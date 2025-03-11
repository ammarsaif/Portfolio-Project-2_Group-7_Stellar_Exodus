using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;

[Serializable]
struct NamePoint
{
	public string name;
	public int point;
}


[Serializable]
struct NamePointArr
{
	public NamePoint[] data;
}

public class LeaderBoard : MonoBehaviour
{
	[SerializeField] private ScoreManager _score;
	[SerializeField] private TextMeshProUGUI _linePrefab;
	[SerializeField] private Transform _recordContainer;

	private string savePath;

	private void Start()
	{
		savePath = Path.Combine(Application.dataPath, "Nikita/data.json");

		if (_recordContainer != null)
		{
			Dictionary<string, int> namePointsList = LoadFromFile();
			var sortedDict = from entry in namePointsList orderby entry.Value ascending select entry;

			foreach (var pair in sortedDict.Reverse().ToArray())
			{
				TextMeshProUGUI newLine = Instantiate(_linePrefab, _recordContainer);
				newLine.text = $"{pair.Key} - {pair.Value}";
			}
		}
	}

	public void GoToGame()
	{
		SceneManager.LoadScene("Game");
	}

	public void GoToMenu()
	{
		SceneManager.LoadScene("Menu");
	}

	public void TrySaveRecord()
	{
		Dictionary<string, int> namePointsList = LoadFromFile();
		string playerName = PlayerPrefs.GetString("PlayerName", "");

		if (playerName != "")
		{
			if (namePointsList.ContainsKey(playerName))
			{
				if (_score.Score > namePointsList[playerName])
					namePointsList[playerName] = _score.Score;
			}
			else
				namePointsList.Add(playerName, _score.Score);
		}

		NamePoint[] newData = new NamePoint[namePointsList.Count];
		int i = 0;
		foreach (var pair in namePointsList)
		{
			newData[i].name = pair.Key;
			newData[i].point = pair.Value;
			i++;
		}

		NamePointArr arr = new NamePointArr();
		arr.data = newData;

		string json = JsonUtility.ToJson(arr, true);

		try
		{
			File.WriteAllText(savePath, json);
		}
		catch
		{
			Debug.LogError("Error with write on file");
		}
	}

	public Dictionary<string, int> LoadFromFile()
	{
		if (!File.Exists(savePath))
		{
			Debug.Log("Have no save data");
			return new Dictionary<string, int>();
		}

		try
		{
			string json = File.ReadAllText(savePath);
			NamePoint[] newData = JsonUtility.FromJson<NamePointArr>(json).data;
			Dictionary<string, int> data = new Dictionary<string, int>();
			foreach (NamePoint pair in newData)
			{
				data.Add(pair.name, pair.point);
			}

			return data;
		}
		catch
		{
			Debug.LogError(">>> read from file");
		}

		return new Dictionary<string, int>();
	}
}