//==========================================================
// Author: J. Orlando
// Description: manage que of customers in game levels
//==========================================================
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class queManager : MonoBehaviour
{
//================= Variables =================//
    [Tooltip("List of customer gameObjects")]
    public List<GameObject> customers = new List<GameObject>();

    GameObject[] activeCustomers;

//================= Core Functions =================//
    // Update is called once per frame
    void Awake()
    {
        GameObject[] activeCustomers = new GameObject[5];
    }

//================= Functions =================//
    void updateActiveQue(List<GameObject> customers)
    {
        int index = 0;

        while (activeCustomers[index] == null)
        {
            index ++;
        }
    }
}
