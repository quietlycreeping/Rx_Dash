/*=========================================================
 Author:     J. Orlando & OU CSI 4380
 Date:       April 2025
 Description: To control the player movement and animations 
==========================================================*/
using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
//================= Variables =================//
    Vector2 clickedPoint;
    RaycastHit2D hitInfo;
    GameObject clickedObject;
    NavMeshAgent agent;
    Vector2 playerDestination;
    //Animator anim;
    //bool isWalk;

    //================= Core Functions =================//
    private void Awake() 
    {
        //anim = GetComponent<Animator>();
        //isWalk = false;

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        //SwitchAnimation();

        if(Input.GetMouseButtonDown(0))
        {
            clickedPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hitInfo = Physics2D.Raycast(clickedPoint, Vector2.zero);
            clickedObject = hitInfo.collider.gameObject;

            if (hitInfo.collider != null)
            {
                if(hitInfo.collider.CompareTag("Ground"))
                {
                    playerDestination = clickedPoint;
                    StartCoroutine(MoveToTarget());
                }
                else if(clickedObject.TryGetComponent(out IClickable clickableObject))
                {
                    Transform childLocation = clickedObject.transform.GetChild(0);
                    playerDestination = childLocation.position;
                    StartCoroutine(MoveToTarget());
                    clickableObject.Interact();
                }
            }
        }
    }

//================= Functions =================//
    IEnumerator MoveToTarget()
    {
        agent.isStopped = false;
        while (Vector3.Distance(transform.position, playerDestination) > 0.5f)
        {
            //isWalk = true;
            agent.destination = playerDestination;
            yield return null;
        }
        //isWalk=false;
        agent.isStopped = true;
    }

    /*void SwitchAnimation()
    {
        anim.SetBool("Walk", isWalk);
    }*/
}
