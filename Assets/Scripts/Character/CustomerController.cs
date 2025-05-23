/*=========================================================
 Author:     J. Orlando
 Date:       April 2025
 Description: Class to manage customers
==========================================================*/
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CustomerController : MonoBehaviour
{
    //================= Variables =================//
    CustomerStats customerStats;
    NavMeshAgent agent;

    //================= Core Functions =================//
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        customerStats = GetComponent<CustomerStats>();
    }
}
