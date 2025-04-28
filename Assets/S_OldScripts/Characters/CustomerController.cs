using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using System.Globalization;

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
    public DateTime birthday; 
    
    [Header("Wait Times")]
    //       0------------5f--------------10f---------------15f------------->
    // Level Start----arriveTime-------quickWait----------maxWait
    //                             time=5>10,+points-----time=10>15, time=>15, -points
    [Tooltip("Time customer will arrive after level start.")]
    public float arriveTime;

    [Tooltip("Time customer will be extra happy (+points) to have the service be finished in.")]
    public float quickWait;

    [Tooltip("Time customer will be content to have the service be finished in.")]
    public float averageWait;
    
    [Tooltip("Last straw customer will behave the service be finished in.")]
    public float maxWait;
    
    float totalWait;
    float timeServed=0;
    bool arrived=false;

    public bool serve=false;

    //================= Core Functions =================//
    private void Awake() 
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Start()
    {
        totalWait = quickWait + averageWait + maxWait;
        
        custArriveChime = GetComponent<AudioSource>();
        StartCoroutine(CustomerArrive());

    }

    private void Update()
    {
        if (arrived == true)
        {
            timeServed += Time.deltaTime;
        //Just left
            if (timeServed>maxWait)
            {
                CustomerExit();
                GameManager.AddScore(-20);
            }
        }

        if (serve == true)
        {
            CustomerExit();
        }
    }

    //================= Functions =================//
    public IEnumerator LineUp(Vector3 queDestination)
    {
        agent.isStopped = false;
        while (Vector3.Distance(transform.position, queDestination) > 0.5f)
        {
            agent.SetDestination(queDestination);
            yield return null;
        }
        agent.isStopped = true;
        arrived=true;
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

    IEnumerator CustomerLeave()
    {
        Debug.Log("leave");
        agent.isStopped = false;
        while (Vector3.Distance(transform.position, queManager.exitSpot) > 0.5f)
        {
            agent.SetDestination(queManager.exitSpot);
            yield return null;
        }
        agent.isStopped = true;
    }

    public void CustomerExit()
    {
        serve = false;
        arrived = false;
        
        //FIXME: hard coded scores
        //Serve quick
        if (timeServed<=quickWait)
        {
            GameManager.AddScore((int)(totalWait*4));
            Debug.Log("quick time" + totalWait*4);
        }
        //Serve average
        else if (timeServed>quickWait && timeServed<=averageWait)
        {
            GameManager.AddScore((int)(totalWait*2));
            Debug.Log("averagr time" + totalWait*2);
        }
        //Serve late
        else if (timeServed>averageWait && timeServed<maxWait)
        {
            GameManager.AddScore((int)totalWait);
            Debug.Log("long time" + totalWait);
        }
        StartCoroutine(CustomerLeave());
        Destroy();
    }

        private void Destroy()
    {
        StopAllCoroutines();
        Destroy(gameObject, 5);
    }
}

