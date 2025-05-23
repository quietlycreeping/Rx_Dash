/*=========================================================
 Author:     J. Orlando
 Date:       April 2025
 Description: Singleton to manage time and timed events
==========================================================*/
using System;
using UnityEngine;

public class TimeManager : GenericSingleton<TimeManager>
{
//================= Events =================//
    public static event Action CustomerArrive;
    //TODO: add event listenter in quemanager

    //================= Variables =================//
    LevelStats levelStats;
    float currentTime;

    //================= Core Functions =================//
    protected override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        levelStats = GameManager.Instance.levelStats;
        currentTime = levelStats.TimeLimit;
    }
    private void Update()
    {

    }

//================= Functions =================//
    void CheckForEvent ()
    {
        CustomerArrive?.Invoke();
    }
}