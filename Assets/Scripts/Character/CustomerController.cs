/*=========================================================
 Author:     J. Orlando
 Date:       April 2025
 Description: Class to manage customers
==========================================================*/
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

// Customer States: HAPPY (++points), CONTENT (+points), UPSET(points), ANGRY (-points), GONE (not in scene)
public enum EmotionCustomer {HAPPY, CONTENT, UPSET, ANGRY, GONE}

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(AudioSource))]
//TODO: Add Animation
//[RequireComponent(typeof(Animator))]
public class CustomerController : MonoBehaviour
{
/*  TimeManager -> compares time to CustomerArriveTime List         | Event CustomerArrive
    QueManager -> Instantiates customer and finds que destination   | Event MoveCustomer
    QueManager -> When queUpdates/Moving Customers around           | Event MoveCustomer
*/
//================= Events =================//
    public static event Action<GameObject> JoinQue;

    //================= Variables =================//
    //Gameobject components
    CustomerStats customerStats;
    NavMeshAgent agent;
    AudioSource custArriveChime;
    //Animator anim;

    //[HideInInspector]
    public EmotionCustomer customerStates;
    float currentWait;
    int currentQueIndex;

    //================= Core Functions =================//
    private void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        customerStates = EmotionCustomer.HAPPY;
        //anim = GetComponent<Animator>();
    }
    private void Start()
    {
        customerStats = GetComponent<CustomerStats>();
        custArriveChime = GetComponent<AudioSource>();
        QueManager.MoveCustomer += CustomerMove;
        StartCoroutine(DelayJoin());
        Debug.Log("quick " + customerStats.QuickWait);
        Debug.Log("average " + customerStats.AverageWait);
        Debug.Log("max " + customerStats.MaxWait);
    }

    private void Update()
    {
        currentWait += Time.deltaTime;
        SwitchState();
    }

    //================= Functions =================//
    IEnumerator DelayJoin()
    {
        yield return null;
        JoinQue?.Invoke(gameObject);
        custArriveChime.Play();
        currentWait = 0;
    }

    private void CustomerMove(Vector2 target, GameObject self)
    {
        if (self == gameObject)
        {
            StopAllCoroutines();
            agent.isStopped = false;
            agent.destination = target;
        }
        else
            return;
    }

    private void SwitchState()
    {
        int time = Mathf.FloorToInt(currentWait);
        Debug.Log("time " + time);
        
        if (time <= customerStats.QuickWait)
            customerStates = EmotionCustomer.HAPPY;
        else if (time <= customerStats.AverageWait)
            customerStates = EmotionCustomer.CONTENT;
        else if (time <= customerStats.MaxWait)
            customerStates = EmotionCustomer.UPSET;
        else
            customerStates = EmotionCustomer.ANGRY;
    }
    private void OnDestroy()
    {
        QueManager.MoveCustomer -= CustomerMove; //unsuscribe from event
    }
}
