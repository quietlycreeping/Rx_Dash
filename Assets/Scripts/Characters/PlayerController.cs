/*=========================================================
 Author:     J. Orlando & OU CSI 4380
 Date:       April 2025
 Description: To control the player movement and animations 
==========================================================*/
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
//================= Variables =================//
    Vector2 clickedPoint;
    RaycastHit2D hitInfo;
    NavMeshAgent agent;
    Vector2 cashRegisterPoint;

//================= Core Functions =================//
    private void Awake() 
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Start()
    {
        cashRegisterPoint = GameObject.Find("playerPoint").transform.position;
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            clickedPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hitInfo = Physics2D.Raycast(clickedPoint, Vector2.zero);

            if (hitInfo.collider != null)
            {
                if(hitInfo.collider.CompareTag("Ground"))
                    MoveToTarget(clickedPoint);
                    
                else if (hitInfo.collider.CompareTag("Checkout"))
                {
                    Debug.Log("cash registr clicked");
                    //TODO: registr function
                    MoveToTarget(cashRegisterPoint);
                }
            }
        }
    }

//================= Functions =================//
    private void MoveToTarget(Vector2 playerDest)
    {
        agent.isStopped = false;
        agent.destination = playerDest;
    }
    
}
