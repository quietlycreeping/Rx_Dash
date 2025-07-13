/*=========================================================
 Author:     J. Orlando
 Date:       April 2025
 Description: Class to manage customer stats
==========================================================*/
using System;
using UnityEngine;

public class CustomerStats : MonoBehaviour
{
    //================= Variables =================//
    public CustomerData_SO templateCustomerData;

    [HideInInspector]
    public CustomerData_SO customerData;
    [HideInInspector]
    public DateTime custBirthday;

    //================= Properties =================// 
    #region Read from CustomerData_SO / Bio
    public string FirstName
    {
        get { if (customerData) return customerData.firstName; else return null; }
        set { customerData.firstName = value; }
    }
    public string LastName
    {
        get { if (customerData) return customerData.lastName; else return null; }
        set { customerData.lastName = value; }
    }
    public int Month
    {
        get { if (customerData) return customerData.month; else return 0; }
        set { customerData.month = value; }
    }
    public int Day
    {
        get { if (customerData) return customerData.day; else return 0; }
        set { customerData.day = value; }
    }
    public int Year
    {
        get { if (customerData) return customerData.year; else return 0; }
        set { customerData.year = value; }
    }
    #endregion

    #region Read from CustomerData_SO / Wait Tolerances
    /*Times will be added together to get total stay
    Example: Total time=15
    ╔═════════════╦═════╦═══════╦═══════╗
    ║   Variable  ║ Set ║ Range ║ Vaule ║
    ╠═════════════╬═════╬═══════╬═══════╣
    ║  quickWait  ║  5  ║  0-5  ║   5   ║
    ╠═════════════╬═════╬═══════╬═══════╣
    ║ averageWait ║  10 ║  6-15 ║   15  ║
    ╠═════════════╬═════╬═══════╬═══════╣
    ║   maxWait   ║  5  ║ 16-20 ║   20  ║
    ╚═════════════╩═════╩═══════╩═══════╝
    */
    public int QuickWait //end time
    {
        get { if (customerData) return customerData.quickWait; else return 0; }
        set { customerData.quickWait = value; }
    }
    public int AverageWait //end time
    {
        get { if (customerData) return customerData.averageWait; return 0; }
        set { customerData.averageWait = value; }
    }
    public int MaxWait //end time
    {
        get { if (customerData) return customerData.maxWait; else return 0; }
        set { customerData.maxWait = value; }
    }
    #endregion

    //================= Core Functions =================//
    private void Awake()
    {
        if (templateCustomerData)
        {
            customerData = Instantiate(templateCustomerData);
        }

        MathWaitTimes();
    }

    //================= Functions =================//
    public void CustomerBirthday(int year, int month, int day)
    {
        try
        { custBirthday = new DateTime(year, month, day); }
        catch (ArgumentOutOfRangeException)
        { Debug.Log("Invalid " + customerData + " birthday"); }
    }

    public void MathWaitTimes()
    {
        AverageWait += QuickWait;
        MaxWait += AverageWait;
    }
}
