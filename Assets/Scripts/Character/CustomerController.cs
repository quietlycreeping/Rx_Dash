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
[RequireComponent(typeof(AudioSource))]
public class CustomerController : MonoBehaviour
{
    /*  TimeManager -> compares time to CustomerArriveTime List         | Event CustomerArrive
        QueManager -> Instantiates customer and finds que destination   | Event MoveCustomer
        QueManager -> When queUpdates/Moving Customers around           | Event MoveCustomer
    */
//================= Events =================//
    public static event Action<GameObject> JoinQue;

//================= Variables =================//
    CustomerStats customerStats;
    NavMeshAgent agent;
    AudioSource custArriveChime;
    int currentQueIndex;

//================= Core Functions =================//
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    private void Start()
    {
        customerStats = GetComponent<CustomerStats>();
        custArriveChime = GetComponent<AudioSource>();
        QueManager.MoveCustomer += CustomerMove;
        StartCoroutine(DelayJoin());
    }

    //================= Functions =================//
    IEnumerator DelayJoin()
    {
        yield return null;
        JoinQue?.Invoke(gameObject);
        custArriveChime.Play();
    }

    private void CustomerMove(Vector2 target, GameObject self)
    {
        if (self != this.gameObject && this != null)
          return;  
        else
        {
            StopAllCoroutines();
            agent.isStopped = false;
            agent.destination = target;
        }
    }
    
}
