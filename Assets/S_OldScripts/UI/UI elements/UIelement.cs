/*=========================================================
 Author:     OU CSI 4380 provided code
 Description: This is the base class for UIelements that 
              are updated by the UI Manager
==========================================================*/
using UnityEngine;

public class UIelement : MonoBehaviour
{
    /// <summary>
    /// Description:
    /// Updates the UI elements UI accordingly
    /// This is a "virtual" function so it can be overridden by classes that inherit from the UIelement class
    /// Input:
    /// None
    /// Return:
    /// void (no return)
    /// </summary>
    public virtual void UpdateUI()
    {

    }
}
