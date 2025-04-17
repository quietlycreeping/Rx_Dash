/*=========================================================
 Author:     OU CSI 4380 provided code
 Description: Class which handles reading Input for other scripts to reference
==========================================================*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputManager : MonoBehaviour
{
// A global instance for scripts to reference
    public static InputManager instance;

    /* <summary>
     Description:
     Standard Unity Function called when the script is loaded
     Input:
     none
     Return:
     void (no return)
     </summary> */
    private void Awake()
    {
        ResetValuesToDefault();
        // Set up the instance of this
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    /* <summary>
     Description:
     Sets all the input variables to their default values so that nothing weird happens in the game if you accidentally
     set them in the editor
     Input:
     none
     Return:
     void
     </summary> */
    void ResetValuesToDefault()
    {
        pauseButton = default;
    }
    
    [Header("Pause Input")]
    [Tooltip("The state of the pause button")]
    public float pauseButton = 0;

    /* <summary>
     Description:
     Collects pause button input
     Input: 
     CallbackContext callbackContext
     Returns:
     void (no return)
     </summary>
     <param name="callbackContext">The context of the pause input</param> */
    public void GetPauseInput(InputAction.CallbackContext callbackContext)
    {
        pauseButton = callbackContext.ReadValue<float>();
    }
}
