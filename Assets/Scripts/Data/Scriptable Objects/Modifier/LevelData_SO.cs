/*=========================================================
 Author:     J. Orlando
 Date:       April 2025
 Description: Scriptable object to hold level data 
==========================================================*/
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "LevelData_SO", menuName = "Scriptable Objects/Manager/Level Data")]
public class LevelData_SO : ScriptableObject
{
    [Header("Level Stats")]
    public int levelNum;
    [Tooltip("In seconds")]
    public float timeLimit;

    [Header("Customers")]
    [Tooltip("Waittime is the time after previous customer arrives or level start")]
    public List<int> customerArriveTime;
    
    [Header("Score Thershold")]
    public int oneStar;
    public int twoStar;
    public int threeStar;
}
