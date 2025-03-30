using UnityEngine;

public class PlayerController : MonoBehaviour
{
//================= Variables =================//
    Vector2 lastClickedPos;
    bool isWalking;
    public float playerSpeed = 10f;

//================= Core Functions =================//
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isWalking=true;
        }

        if (isWalking && (Vector2)transform.position != lastClickedPos)
        {
            MoveToTarget(lastClickedPos);
        }
    }

//================= Functions =================//
    private void MoveToTarget(Vector2 playerDestination)
    {
            float step = playerSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, lastClickedPos,step);
    }
}
