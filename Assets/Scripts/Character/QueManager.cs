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

public class QueManager : GenericSingleton<QueManager>
{
    /*  TimeManager -> compares time to CustomerArriveTime List         | Event CustomerArrive
        QueManager -> Instantiates customer and finds que destination   | Event MoveCustomer
        QueManager -> When queUpdates/Moving Customers around           | Event MoveCustomer
    */
    //================= Events =================//
    public static event Action<Vector2, GameObject> MoveCustomer;

    //================= Variables =================//
    int maxQueSize;
    GameObject[] customerList; //random generated array of customers based of level stats # of customers
    List<GameObject> linedupCustomers = new(); //customers who have arrived

    [Header("Que Spots")]
    public GameObject[] queSpots;
    public int startIndex;
    public int exitIndex;
    public GameObject cloneFolder;

    //================= Core Functions =================//
    protected override void Awake()
    {
        base.Awake();return;
    }

    public void Start()
    {
        GenerateCustomerArray();

        TimeManager.Instance.CustomerArrive += CreateCustomer;
        CustomerController.JoinQue += JoinQue;
    }

    //================= Functions =================//
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

    public void CreateCustomer(int index)
    {
        GameObject activeCustomer = customerList[index]; //index should be same as time index
        Instantiate(activeCustomer, cloneFolder.transform, true);
    }

    public void JoinQue(GameObject customer)
    {
        int positionNum = Math.Min(startIndex, linedupCustomers.Count); //put customer in either visible spot or wait spot off camera
        linedupCustomers.Add(customer);
        MoveCustomer?.Invoke(queSpots[positionNum].transform.position, customer);
    }

    public void UpdateQue(int emptySpot)
    {
        linedupCustomers.RemoveAt(emptySpot);

        for (int i = 0; i < linedupCustomers.Count - 1; i++)
        {
            MoveCustomer?.Invoke(queSpots[i].transform.position, linedupCustomers[i]);

        }
    }
}
