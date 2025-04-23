using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(AudioSource))]
public class CustomerController : MonoBehaviour
{
//================= Variables =================//    
    [Header("Components")]
    public QueManager queManager;
    AudioSource custArriveChime;
    NavMeshAgent agent;
    //GameObject customer;

    [Header("Bio")]
    [Tooltip("Customer first name")]
    public string firstName;
    [Tooltip("Customer last name")]
    public string lastName;
    //something to list what drugs they need
    
    [Header("Birthday")]
    public float month = 5;
    public float day = 22;
    public float year = 1994;
    
    [Header("Wait Times")]
    //       0------------5f--------------10f---------------15f------------->
    // Level Start----arriveTime-------quickWait----------maxWait
    //                             time=5>10,+points-----time=10>15, time=>15, -points
    [Tooltip("Time customer will arrive after level start.")]
    public float arriveTime;
    private float currentWaitStart;
    [Tooltip("Time customer will be extra happy (+points) to have the service be finished in.")]
    public float quickWait;
    [Tooltip("Time customer will be content to have the service be finished in.")]
    public float maxWait;

    //================= Core Functions =================//
    private void Awake() 
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Start()
    {
        custArriveChime = GetComponent<AudioSource>();
        StartCoroutine(CustomerArrive());
    }

    //================= Functions =================//
    public IEnumerator LineUp(Vector3 queDestination)
    {
        agent.isStopped = false;
        while (Vector3.Distance(transform.position, queDestination) > 0.1f)
        {
            agent.SetDestination(queDestination);
            yield return null;
        }
        agent.isStopped = true;
    } 

    IEnumerator CustomerArrive()
    {
        yield return new WaitForSeconds(arriveTime);
        Debug.Log("Customer " + firstName + " arrived");
        if (queManager != null)
        {
            queManager.QueNewCust(gameObject);
            custArriveChime.Play();
        }
    }
}

