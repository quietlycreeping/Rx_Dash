/*=========================================================
 Author:     J. Orlando
 Date:       April 2025
 Description: Singleton to manage mouse input
==========================================================*/
using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputManager : GenericSingleton<InputManager>
{
//================= Events =================//
    public event Action<Vector2> OnGroundClicked;

//================= Variables =================//
    RaycastHit2D hitInfo;
    Vector2 clickedPoint;
    public float pauseButton = 0; //state of pause button

//================= Core Functions =================//
    protected override void Awake()
    {
        base.Awake();
    }
    private void Update()
    {
        GetRayPoint();
        MouseControl();
    }

    //================= Functions =================//
    private void GetRayPoint()
    {
        clickedPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        hitInfo = Physics2D.Raycast(clickedPoint, Vector2.zero);
    }

    void MouseControl()
    {
        if (Input.GetMouseButtonDown(0) && hitInfo.collider != null)
        {
            if (hitInfo.collider.gameObject.CompareTag("Ground"))
            {
                OnGroundClicked?.Invoke(clickedPoint);
            }
        }
    }

    public void GetPauseInput(InputAction.CallbackContext context)
    {
        pauseButton = context.ReadValue<float>();
    }
}