/*=========================================================
 Author:     J. Orlando
 Date:       April 2025
 Description: Scriptable object to hold level data 
==========================================================*/
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData_SO", menuName = "Scriptable Objects/LevelData_SO")]
public class LevelData_SO : ScriptableObject
{
    [Header("Level Stats")]
    public int levelNum;
    public float timeLimit;
    public int customerAmount;
    
    [Header("Score Thershold")]
    public int oneStar;
    public int twoStar;
    public int threeStar;
}
