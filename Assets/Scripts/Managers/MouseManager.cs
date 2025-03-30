using UnityEngine;
using System;

public class MouseManager : MonoBehaviour
{
    public static MouseManager Instance;
    public event Action<Vector2> OnMouseClicked;
    RaycastHit2D hitInfo;

//================= Core Functions =================//
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }
    private void Update()
    {
        MouseControl();
    }
//================= Functions =================//
    void MouseControl()
    {
        if(Input.GetMouseButtonDown(0) && hitInfo.collider != null)
        {
            if(hitInfo.collider.gameObject.CompareTag("Ground"))
            {
                OnMouseClicked?.Invoke(hitInfo.point);
                Debug.Log(hitInfo);
            }
        }
    }
}
