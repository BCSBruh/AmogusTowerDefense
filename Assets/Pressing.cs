using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pressing : MonoBehaviour
{
    public string levelToLoad = "Main Level";
    public void PlayPressed()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void QuitPressed()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void PauseQuitPressed()
    {
        SceneManager.LoadScene(levelToLoad);
        Time.timeScale = 1f;
    }
}
