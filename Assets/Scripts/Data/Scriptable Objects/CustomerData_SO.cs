/*=========================================================
 Author:     J. Orlando
 Date:       April 2025
 Description: Scriptable object to hold customer data 
==========================================================*/
using UnityEngine;
using System.Collections.Generic;
using System.Globalization;
using System;

[CreateAssetMenu(fileName = "CustomerData_SO", menuName = "Scriptable Objects/CustomerData_SO")]
public class CustomerData_SO : ScriptableObject
{
    [Header("Bio")]
    public GameObject custPrefab;
    public string firstName;
    public string lastName;

    [Header("Birthday")]
    public int month;
    public int day;
    public int year;
    
    [Header("Wait Tolerances")]
    /*Times will be added together to get total stay
    Ex. Total time=15
     +-------------+-----+-------+ 
     |  Variable   | Set | Range | 
     +-------------+-----+-------+ 
     | quickWait   |   5 | 0-5   | 
     | averageWait |  10 | 6-10  | 
     | maxWait     |   5 | 11-15 | 
     +-------------+-----+-------+ 
    */
    [Tooltip("Time customer will be extra happy (+points) to have their service be finished in.")]
    public float quickWait;
    [Tooltip("Time customer will be content to have the service be finished in.")]
    public float averageWait;
    [Tooltip("Last straw. Customer will leave at end of time and even if service is not done.")]
    public float maxWait;

    [Space(10)]
    public List<ScriptableObject> medicine;
}
