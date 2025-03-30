using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Numerics;
using JetBrains.Annotations;
using UnityEditor.Rendering;

public class Customer : MonoBehaviour
{
//================= Variables =================//
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
    private UnityEngine.Vector2 newPositon;

    //================= Core Functions =================//
    void Awake()
    {
        StartCoroutine(CustomerArrive());
    }
    void Start()
    {
        newPositon = new UnityEngine.Vector2(4f,-3.5f);
    }
    //================= Functions =================//
    IEnumerator CustomerArrive()
    {
        yield return new WaitForSeconds(arriveTime);
        Debug.Log("Customer " + firstName + " arrived");
    }
}
 