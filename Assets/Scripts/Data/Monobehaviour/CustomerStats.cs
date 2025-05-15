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
public CustomerData_SO customerData;

public DateTime custBirthday;

//================= Properties =================// 
    #region Read from CustomerData_SO / Bio
    public string FirstName{
        get {if (customerData) return customerData.firstName; else return "null";}
        set{customerData.firstName = value;}}
    public string LastName{
        get {if (customerData) return customerData.lastName; else return "null";}
        set{customerData.lastName = value;}}
    public int Month{
        get {if (customerData) return customerData.month; else return 0;}
        set {customerData.month = value;}
    }
    public int Day{
        get {if (customerData) return customerData.day; else return 0;}
        set {customerData.day = value;}
    }
    public int Year{
        get {if (customerData) return customerData.year; else return 0;}
        set {customerData.year = value;}
    }
    #endregion

    #region Read from CustomerData_SO / Wait Tolerances
    public float QuickWait{
        get {if (customerData) return customerData.quickWait; else return 0;}
        set {customerData.quickWait = value;}
    }
    public float AverageWait{
        get {if (customerData) return customerData.averageWait; return 0;}
        set {customerData.averageWait = value;}
    }
    public float MaxWait{
        get {if (customerData) return customerData.maxWait; else return 0;}
        set {customerData.maxWait = value;}
    }
    #endregion
//================= Core Functions =================//
    void Start()
    {
        custBirthday = new DateTime(Year, Month, Day);
    }
}
