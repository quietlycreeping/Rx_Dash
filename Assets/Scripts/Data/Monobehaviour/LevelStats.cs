/*=========================================================
 Author:     J. Orlando
 Date:       April 2025
 Description: Class to manage level stats
==========================================================*/
using System;
using UnityEngine;
using System.Collections.Generic;
using Unity.Properties;

public class LevelStats : MonoBehaviour
{
//================= Variables =================//
    public LevelData_SO readonlyLevelData;

    [HideInInspector]
    public LevelData_SO levelData;

//================= Core Functions =================//
    private void Awake()
    {
        if (readonlyLevelData)
        {
            levelData = Instantiate(readonlyLevelData);
        }
    }

//================= Properties =================// 
    #region Read from LevelData_SO / Stats
    public int LevelNum
    {
        get { if (levelData) return levelData.levelNum; else return 0; }
        set { levelData.levelNum = value; }
    }
    public float TimeLimit
    {
        get { if (levelData) return levelData.timeLimit; else return 0; }
        set { levelData.timeLimit = value; }
    }
    #endregion

    #region Read from LevelData_SO / Score Thershold
    public int OneStar
    {
        get { if (levelData) return levelData.oneStar; else return 0; }
        set { levelData.oneStar = value; }
    }
    public int TwoStar
    {
        get { if (levelData) return levelData.twoStar; else return 0; }
        set { levelData.twoStar = value; }
    }
    public int ThreeStar
    {
        get { if (levelData) return levelData.threeStar; else return 0; }
        set { levelData.threeStar = value; }
    }
    #endregion

    #region Read from LevelData_SO / Customers
    public List<int> CustomerArriveTime
    {
        get { if (levelData) return levelData.customerArriveTime; else return null; }
        set { levelData.customerArriveTime = value; }
    }
    public int CustomerAmount
    {
        get
        {
            if (levelData && levelData.customerArriveTime != null) return levelData.customerArriveTime.Count;
            else return 0;
        }
    }
    #endregion

}
