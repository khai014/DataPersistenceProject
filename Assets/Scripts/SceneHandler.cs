using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
	public void LoadMainScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(0);
    }


    public void Exit()
    {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
                Application.Quit(); // original code to quit Unity player
#endif
    }
}
