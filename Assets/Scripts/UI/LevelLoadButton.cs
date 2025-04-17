/*=========================================================
 Author:     OU CSI 4380 provided code
 Description: This class is meant to be used on buttons 
              as a quick easy way to load levels (scenes)
==========================================================*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoadButton : MonoBehaviour
{
    /* <summary>
     Description:
     Loads a level according to the name provided
     Input:
     string levelToLoadName
     Return:
     void (no return)
     </summary>
     <param name="levelToLoadName">The name of the level to load</param> */
    public void LoadLevelByName(string levelToLoadName)
    {
        SceneManager.LoadScene(levelToLoadName);
    }
}
