//==========================================================
// Author: J. Orlando
// Description: manage que of customers in game levels
//==========================================================
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class QueManager : MonoBehaviour
{
//================= Variables =================//
    [Tooltip("List of customer gameObjects")]
    public List<GameObject> customers = new List<GameObject>();
    
    //hardcoded location spots that are children of the queManager
    List <Vector3>QueSpots;
    int spotNumber;
    [HideInInspector]
    public Vector3 exitSpot;

   //list of customers in line
    List <GameObject>CustomersQue=new();
//================= Core Functions =================//
    // Update is called once per frame
    private void Awake()
    {
        spotNumber = transform.childCount;
        QueSpots = new List<Vector3>();
        CustomersQue = new List<GameObject>(new GameObject[spotNumber]);
        exitSpot = transform.GetChild(7).position; 
        
        //queSpots and customerQue populate 
        for (int i =0;i<spotNumber;i++)
        {
            QueSpots.Add(transform.GetChild(i).position);
        }
    }


    //================= Functions =================//
    public void QueNewCust(GameObject customer)
    {   
        var customerController = customer.GetComponent<CustomerController>();
        for (int i=0;i<spotNumber;i++)
        {
            if (CustomersQue[i] == null)
            {
                CustomersQue[i] = customer;
                StartCoroutine(customerController.LineUp(QueSpots[i]));
                break;
            }
        }
    }

    public void UpdateQue(GameObject customer)
    {

    }
}
