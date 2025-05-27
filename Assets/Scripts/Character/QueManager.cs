/*=========================================================
 Author:     J. Orlando
 Date:       April 2025
 Description: Class to manage que order
==========================================================*/
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class QueManager : MonoBehaviour
{
    //================= Variables =================//

    int queSize;
    public GameObject[] customerList;

    //================= Core Functions =================//
    public void Start()
    {
        GenerateQue();
    }

    //================= Functions =================//
    public void GenerateQue()
    {
        //TODO: add valdiator for when queSize > allCustomerList
        
        queSize = GameManager.Instance.levelStats.CustomerAmount;
        customerList = new GameObject[queSize];
        List<GameObject> allCustomerList = GameManager.Instance.levelStats.CustomerList;

        for (int i = queSize-1; i > -1; i--)
        {
            int customerIndex = Random.Range(0, allCustomerList.Count - 1);
            customerList[i] = allCustomerList.ElementAt(customerIndex);
            allCustomerList.RemoveAt(customerIndex);
        }
    }
}
