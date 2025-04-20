using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{

    public UIManager uIManager;
//================= Variables =================//
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Time Settings")]
    public float levelTime;
    float currentTime;
    bool countDown = true;

    bool hasLimit = true;
    float timerLimit = 0;
    bool overTime = false;

    //================= Core Functions =================//
    public void Awake()
    {
        //uIManager = GetComponent<UIManager>();
        currentTime = levelTime;
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
                timerText.color = Color.red;
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
