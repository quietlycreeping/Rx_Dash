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

    [Header("Score Thershold")]
    public int oneStar;
    public int twoStar;
    public int threeStar;

    [Header("Time Settings")]
    [Tooltip("In seconds")]
    public float timeLimit;
    [Tooltip("Time before zero that a notification to the player happens. In seconds.")]
    public int warningTime = 20;
    [Tooltip("Modifier to multiply timeLimit (fraction 0.3) to set overtime amount")]
    public float overTimeMod = 0.3f;

    [Header("Customers")]
    public int empty;
    [Space(50)]
    [Tooltip("Time is total time it takes to arrive. From game start till they arrive. Ex:2 secs into game play")]
    public List<int> customerArriveTime;
}
