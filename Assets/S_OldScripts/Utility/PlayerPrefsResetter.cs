/*================================================================
 Author:     OU CSI 4380 provided code
 Description: This class uses the game manager's reset game 
              player prefs function to reset the score player prefs
=================================================================*/
using UnityEngine;

public class PlayerPrefsResetter : MonoBehaviour
{
    /* <summary>
     Description:
     Calls the GameManger Reset Score function to reset the score player preference data
     Input:
     none
     Return:
     void (no return)
     </summary> */
    public void ResetGamePlayerPrefs()
    {
        GameManager.ResetGamePlayerPrefs();
    }
}
