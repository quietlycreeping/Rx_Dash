/*=========================================================
 Author:     J. Orlando
 Date:       April 2025
 Description: Class to read the scriptable object that contains
              the score modifers
==========================================================*/
using UnityEngine;

public class ScoreStats : MonoBehaviour
{
    public ScoreData_SO scoreData;

//================= Properties =================// 
#region Read from ScoreData_SO
public float EarlyFinishMod{
    get {if (scoreData) return scoreData.earlyFinishMod; else return 0;}
    set{scoreData.earlyFinishMod = value;}}
public float AverageFinishMod{
    get {if (scoreData) return scoreData.averageFinishMod; else return 0;}
    set{scoreData.averageFinishMod = value;}}
public float LateFinishMod{
    get {if (scoreData) return scoreData.lateFinishMod; else return 0;}
    set{scoreData.lateFinishMod = value;}}
public int MissScore{
    get {if (scoreData) return scoreData.missScore; else return 0;}
    set{scoreData.missScore = value;}}

#endregion
}
