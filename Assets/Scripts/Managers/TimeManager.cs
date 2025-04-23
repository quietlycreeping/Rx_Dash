using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;


[RequireComponent(typeof(AudioSource))]
public class TimeManager : MonoBehaviour
{
//================= Variables =================//
    [Header("Components")]
    AudioSource warningJingle;
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
        warningJingle = GetComponent<AudioSource>();
        StartCoroutine(WarningJinglePlay());
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
                GameManager.instance.GameOver();
                hasLimit=false;
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

    IEnumerator WarningJinglePlay()
    {
        yield return new WaitForSeconds(levelTime-warningTime);
        warningJingle.Play();
    }
}
