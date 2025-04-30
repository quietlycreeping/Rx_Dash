/*=========================================================
 Author:     J. Orlando
 Date:       April 2025
 Description: Class to manage player control
==========================================================*/
using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
//================= Variables =================//   
    NavMeshAgent agent;

//================= Core Functions =================//
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    private void Start()
    {
        MouseManager.Instance.OnGroundClicked += PlayerMovement;
    }

//================= Functions =================//
    public void PlayerMovement(Vector2 target)
    {
        StopAllCoroutines();

        agent.isStopped = false;
        agent.destination = target;
    }
}
