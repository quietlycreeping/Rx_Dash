/*=========================================================
 Author:     J. Orlando
 Date:       April 2025
 Description: Class to manage que order
==========================================================*/
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;

public class QueManager : MonoBehaviour
{
    /*  TimeManager -> compares time to CustomerArriveTime List         | Event CustomerArrive
        QueManager -> Instantiates customer and finds que destination   | Event MoveCustomer
        QueManager -> When queUpdates/Moving Customers around           | Event MoveCustomer
    */
    //================= Events =================//
    public static event Action<Vector2,GameObject> MoveCustomer; 

    //================= Variables =================//
    int maxQueSize;
    GameObject[] customerList; //random generated array of customers based of level stats # of customers
    List<GameObject> linedupCustomers = new(); //customers who have arrived

    //queSpots
    Vector2[] queSpots; //hardcoded location spots that are children of the queManager
    int queSpotAmount;
    int queStartSpot;
    int queExitSpot;

    //================= Core Functions =================//
    public void Awake()
    {
        GenerateQueSpots();
    }
    public void Start()
    {
        GenerateCustomerArray();
        GenerateLinedUpList();

        TimeManager.Instance.CustomerArrive += CreateCustomer;
        CustomerController.JoinQue += QueUp;
    }

    //================= Functions =================//
    #region  Generate Lists/Array
    public void GenerateCustomerArray()
    {
        //queSize= levelStats customer amount or levelStats customer list amount; which ever is smaller
        maxQueSize = Math.Min(GameManager.Instance.levelStats.CustomerAmount, GameManager.Instance.levelStats.CustomerList.Count);
        customerList = new GameObject[maxQueSize];
        List<GameObject> allCustomerList = GameManager.Instance.levelStats.CustomerList;

        for (int i = 0; i < maxQueSize; i++)
        {
            int customerIndex = Random.Range(0, allCustomerList.Count - 1);
            customerList[i] = allCustomerList.ElementAt(customerIndex);
            allCustomerList.RemoveAt(customerIndex);
        }
    }

    private void GenerateQueSpots()
    {
        queSpotAmount = transform.childCount;
        queSpots = new Vector2[queSpotAmount];

        for (int i = 0; i < queSpotAmount; i++)
        {
            queSpots[i] = transform.GetChild(i).position;
        }

        queStartSpot = queSpotAmount - 2;
        queExitSpot = queSpotAmount - 1;
    }

    private void GenerateLinedUpList()
    {
        linedupCustomers = new List<GameObject>(maxQueSize);
        for (int i = 0; i < maxQueSize; i++)
        {
            linedupCustomers.Add(null);
        }
    }
    #endregion

    public void CreateCustomer(int index)
    {
        GameObject activeCustomer = customerList[index]; //index should be same as time index
        Instantiate(activeCustomer);
    }

    public void QueUp(GameObject customer)
    {
        for (int i = 0; i < maxQueSize; i++)
        {
            if (linedupCustomers[i] == null)
            {
                linedupCustomers[i] = customer;
                int postionNum = Math.Min(queStartSpot, i);
                MoveCustomer?.Invoke(queSpots[postionNum], customer);

                break;
            }
        }
    }
    
    public void UpdateQue(GameObject customer)
    {
        int i = 0;
        while (linedupCustomers[i] != null)
            i++;

        linedupCustomers[i] = customer;
        //MoveCustomer?.Invoke(queSpots[1]); 
    }
}
