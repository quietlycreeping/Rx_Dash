/*=========================================================
 Author:     OU CSI 4380 provided code
 Description: This class stores relevant information 
              about a page of UI
==========================================================*/
using UnityEngine;

public class UIPage : MonoBehaviour
{
    [Tooltip("The default UI to have selected when opening this page")]
    public GameObject defaultSelected;

    /* <summary>
     Description:
     Sets the currently selected UI to the one defaulted by this UIPage
     Input:
     none
     Return:
     void (no return)
     </summary> */
    public void SetSelectedUIToDefault()
    {
        if (GameManager.instance != null && GameManager.instance.uiManager != null && defaultSelected != null)
        {
            GameManager.instance.uiManager.eventSystem.SetSelectedGameObject(null);
            GameManager.instance.uiManager.eventSystem.SetSelectedGameObject(defaultSelected);
        }
        
    }
}
