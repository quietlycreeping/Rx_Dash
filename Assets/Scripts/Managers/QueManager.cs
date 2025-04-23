//==========================================================
// Author: J. Orlando
// Description: manage que of customers in game levels
//==========================================================
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class QueManager : MonoBehaviour
{
    CustomerController customerController;
//================= Variables =================//
    [Tooltip("List of customer gameObjects")]
    public List<GameObject> customers = new List<GameObject>();
    
    //hardcoded location spots that are children of the queManager
    List <Vector3>QueSpots;
    int spotNumber;

   //list of customers in line
    List <GameObject>CustomersQue=new List<GameObject>();
//================= Core Functions =================//
    // Update is called once per frame
    private void Awake()
    {
        spotNumber = transform.childCount;
        QueSpots = new List<Vector3>();
        CustomersQue = new List<GameObject>(new GameObject[spotNumber]); 
        
        //queSpots and customerQue populate 
        for (int i =0;i<spotNumber;i++)
        {
            QueSpots.Add(transform.GetChild(i).position);
        }
    }

    private void Update()
    {

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
}
