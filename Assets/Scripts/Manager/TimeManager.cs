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
    /*  TimeManager -> compares time to CustomerArriveTime List         | Event CustomerArrive
        QueManager -> Instantiates customer and finds que destination   | Event MoveCustomer
        QueManager -> When queUpdates/Moving Customers around           | Event MoveCustomer
    */
//================= Events =================//
    public event Action<int> CustomerArrive;

//================= Variables =================//
    [Header("Components")]
    LevelStats levelStats;
    public TextMeshProUGUI timerText;

    //Time---
    float currentTime;
    int warningTime;
    float overtimeTime;
    //Timer---
    bool countDown = true;
    bool hasLimit = true;
    float timerLimit = 0;
    bool overTime = false;

    List<int> customerTime = new();
    int customerIndex = 0;

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

        if (customerIndex < customerTime.Count)
            CheckTimeEvent(currentTime);
    }

    void DisplayTime(float activeTime)
    {
        if(activeTime < 0)
        {
            activeTime = 0;
        }
        
        float minutes = Mathf.FloorToInt(activeTime / 60);
        float seconds = Mathf.FloorToInt(activeTime % 60);

        if (timerText != null)
        {
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
    public void CheckTimeEvent(float activeTime)
    {
        if (customerTime[customerIndex] == Mathf.FloorToInt(activeTime))
        {
            CustomerArrive?.Invoke(customerIndex);
            customerIndex++;
        }
    }
}