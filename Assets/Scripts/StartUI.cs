using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class StartUI : MonoBehaviour
{
    [SerializeField] private GameObject _noPlayerNameWarning;
	[SerializeField] private TMP_InputField _playerNameInputField;

    private GameObject _bestScoreObject;
    private string _bestScorePlayerNameText;
    private int _bestScoreText;
    private SceneHandler _sceneHandler;

    void Start()
    {
        Debug.Log(Application.persistentDataPath);
        _noPlayerNameWarning.SetActive(false);
        _sceneHandler = GetComponent<SceneHandler>();

        _bestScorePlayerNameText = DataHandler.Instance._playerNameBestScore;
        _bestScoreText = DataHandler.Instance._playerBestScore;

        _bestScoreObject = GameObject.Find("BestScore");
        ShowBestScoreText();
    }

    public void StartGame()
    {
        if (_playerNameInputField.text == "")
        {
            _noPlayerNameWarning.SetActive(true);
        }
        else
        {
            DataHandler.Instance._currentPlayerName = _playerNameInputField.text;
            _sceneHandler.LoadMainScene();
        }
    }

    public void ResetHighScore()
    {
        DataHandler.Instance.ResetPlayerData();
        DataHandler.Instance.LoadPlayerData();
        ResetBestScoreText();
    }

    private void ShowBestScoreText()
    {
        _bestScoreObject.GetComponent<TMP_Text>().text = "Best Score : " + _bestScorePlayerNameText + " : " + _bestScoreText;
    }

    private void ResetBestScoreText()
    {
        _bestScoreObject.GetComponent<TMP_Text>().text = "Best Score : " + " " + " : " + 0;
    }
}