/*=========================================================
 Author:     J. Orlando
 Date:       April 2025
 Description: Class to manage level stats
==========================================================*/
using System;
using UnityEngine;
using UnityEngine.Video;

public class LevelStats : MonoBehaviour
{
//================= Variables =================//
public LevelData_SO levelData;

//================= Properties =================// 
    #region Read from LevelData_SO / Stats
    public int LevelNum{
        get {if (levelData) return levelData.levelNum; else return 0;}
        set {levelData.levelNum = value;}
    }
    public float TimeLimit {
        get {if (levelData) return levelData.timeLimit; else return 0;}
        set {levelData.timeLimit = value;}
    }
    public int CustomerAmount{
        get {if (levelData) return levelData.customerAmount; else return 0;}
        set {levelData.customerAmount = value;}
    }
    #endregion

    #region Read from LevelData_SO / Score Thershold
    public int OneStar{
        get {if (levelData) return levelData.oneStar; else return 0;}
        set {levelData.oneStar = value;}}
    public int TwoStar{
        get {if (levelData) return levelData.twoStar; else return 0;}
        set {levelData.twoStar = value;}}
    public int ThreeStar{
        get {if (levelData) return levelData.threeStar; else return 0;}
        set {levelData.threeStar = value;}}
    #endregion

}
