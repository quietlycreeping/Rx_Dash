/*=========================================================
 Author:     J. Orlando
 Date:       May 2025
 Description: Class to manage pages of different UI elements
==========================================================*/
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.EventSystems;
using System;

public class UIManager : MonoBehaviour
{
    //================= Variables =================//
    [Header("UI Page Managment")]
    public List<GameObject> pages;
    public int defaultPageIndex;

    [Header("Pause Settings")]
    [Tooltip("The index of the pause page in the pages list")]
    public int pausePageIndex;
    [Tooltip("Whether or not to allow pausing")]
    public bool allowPause = true;
    private bool isPaused = false; // Whether the game is paused

    [Header("Managers")]
    public InputManager inputManager; // The Input Manager to listen for pausing
    [HideInInspector]
    public EventSystem eventSystem; // The event system handling UI navigation

    //================= Core Functions =================//
    private void Update()
    {
        CheckPauseInput();
    }

    //================= Functions =================//
    private void CheckPauseInput()
    {
        if (inputManager != null)
        {
            if (inputManager.pauseButton == 1)
            {
                TogglePause();
                inputManager.pauseButton = 0;
            }
        }
    }
    public void TogglePause()
    {
        if (allowPause)
        {
            if (isPaused)
            {
                ActivatePage(defaultPageIndex);
                Time.timeScale = 1;
                isPaused = false;
            }
            else
            {
                ActivatePage(pausePageIndex);
                Time.timeScale = 0;
                isPaused = true;
            }
        }
    }

    public void ActivatePage(int pageIndex)
    {
        if (pageIndex < pages.Count && pages[pageIndex] != null)
        {
            for (int i = 0; i < pages.Count; i++)
            {
                if (i == pageIndex)
                {
                    pages[i].SetActive(true);
                }
                else
                    pages[i].SetActive(false);
            }
        }
    }
}
