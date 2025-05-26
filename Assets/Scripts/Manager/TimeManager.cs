/*=========================================================
 Author:     J. Orlando
 Date:       April 2025
 Description: Singleton to manage time and timed events
==========================================================*/
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimeManager : GenericSingleton<TimeManager>
{
//================= Events =================//
    public static event Action CustomerArrive;
    //TODO: add event listenter in quemanager

//================= Variables =================//
    [Header("Components")]
    LevelStats levelStats;
    public TextMeshProUGUI timerText;

    //Time---
    float currentTime;
    int warningTime;
    float overtimeTime;
    List<int> customerTime;
    bool countDown = true;
    bool hasLimit = true;
    float timerLimit = 0;
    bool overTime = false;

    //================= Core Functions =================//
    protected override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        levelStats = GameManager.Instance.levelStats;
        currentTime = levelStats.TimeLimit;
        warningTime = levelStats.WarningTime;
        overtimeTime = currentTime * levelStats.OverTimeMod;
        customerTime = levelStats.CustomerArriveTime;
    }
    private void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        CountTime();
    }

    //================= Functions =================//
    void CountTime()
    {
        if (hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
        {
            if (overTime == false)
            {
                countDown = false;
                currentTime = 0;
                timerLimit = overtimeTime;
                overTime = true;
            }
            else
            {
                //TODO: Add gameover screen
                hasLimit = false;
                Time.timeScale = 0;
            }
        }
        DisplayTime(currentTime);
        //CheckTimeEvent(currentTime);
    }

    void DisplayTime(float time)
    {
        if(time < 0)
        {
            time = 0;
        }
        
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        if (timerText != null)
        {
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
    void CheckTimeEvent(float currentTime)
    {
        CustomerArrive?.Invoke();
    }
}