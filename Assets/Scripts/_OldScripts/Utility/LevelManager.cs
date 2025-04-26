/*=========================================================
 Author:     OU CSI 4380 provided code
 Description: Class to help with switching between scenes
==========================================================*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    /* <summary>
     Description:
     Loads a scene by name
     Input:
     string sceneName
     Return:
     void (no return)
     </summary>
     <param name="sceneName">The name of the scene to be loaded</param> */
    public static void LoadScene(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }
}
