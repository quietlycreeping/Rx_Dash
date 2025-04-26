/*=========================================================
 Author:     OU CSI 4380 provided code
 Description: This class handles quitting out of the game
              Closes the game or exits play mode depending on the case
==========================================================*/
using UnityEngine;

public class QuitGameButton : MonoBehaviour
{    public void QuitGame() 
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
