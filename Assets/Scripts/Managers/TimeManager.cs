using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;


public class TimeManager : MonoBehaviour
{

    public UIManager uIManager;
    
    public AudioSource warningJingle;

//================= Variables =================//
    [Header("Components")]
    public TextMeshProUGUI timerText;
    public Image clock;
    public Image bar;

    [Header("Time Settings")]
    public float levelTime;
    public float warningTime;
    float currentTime;
    bool countDown = true;

    bool hasLimit = true;
    float timerLimit = 0;
    bool overTime = false;

    Color32 red = new Color32(212,31,27,255);

    //================= Core Functions =================//
    public void Awake()
    {
        currentTime = levelTime;
    }

    public void Start()
    {
        warningJingle.PlayDelayed(levelTime-warningTime);
    }
    public void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        if (hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
        {
            if (overTime == false)
            {
                countDown = false;
                currentTime = 0;
                timerLimit = levelTime;
                overTime = true;
                bar.color = red;
                clock.color = red; 
            }
            else
            {
                Time.timeScale = 0;
                enabled = false;
                Debug.Log("Gameover");
                uIManager.GoToPage(3);
            }
        }

        DisplayTime(currentTime);

    }


    //================= Functions =================//
    void DisplayTime(float time)
    {
        if(time < 0)
        {
            time = 0;
        }
        
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
