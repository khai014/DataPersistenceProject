using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private TMP_InputField _playerNameInputField;
    private string _playerName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _playerName = _playerNameInputField.ToString();
    }
}
