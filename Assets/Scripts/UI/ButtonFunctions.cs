/*=========================================================
 Author:     J. Orlando
 Date:       May 2025
 Description: Class that holds various functions for UI buttons
==========================================================*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public void LoadSceneName(string scenceName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(scenceName);
    }
    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GameQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}