using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    public static DataHandler Instance;

    public string _playerNameBestScore;
    public string _currentPlayerName;
    public int _currentScore;
    public int _playerBestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadPlayerData();
    }

	[System.Serializable]
    class SaveData
    {
        public string _playerNameBestScore;
        public int _playerBestScore;
    }

    public void SavePlayerData()
    {
        SaveData data = new SaveData();
        data._playerNameBestScore = _currentPlayerName;
        data._playerBestScore = _currentScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            _playerNameBestScore = data._playerNameBestScore;
            _playerBestScore = data._playerBestScore;
        }
    }

    public void ResetPlayerData()
    {
        SaveData data = new SaveData();
        data._playerNameBestScore = "";
        data._playerBestScore = 0;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
}
