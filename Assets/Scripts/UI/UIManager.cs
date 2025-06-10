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

    [Header("UI Effects")]
    public GameObject onHoverEffect;
    public GameObject clickEffect;
    public GameObject backClickEffect;

    [Header("Managers")]
    public GameObject uICloneFolder;
    public InputManager inputManager; // The Input Manager to listen for pausing
    [HideInInspector]
    public EventSystem eventSystem; // The event system handling UI navigation

//================= Core Functions =================//
    private void Awake()
    {
        ActivateDefaultPage(defaultPageIndex);
    }
    private void Update()
    {
        if (allowPause && inputManager != null)
        { CheckPauseInput(); }
    }

//================= Functions =================//
    #region Pause Functions
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
                GoToPage(defaultPageIndex);
                Time.timeScale = 1;
                isPaused = false;
            }
            else
            {
                GoToPage(pausePageIndex);
                Time.timeScale = 0;
                isPaused = true;
            }
        }
    }
    #endregion

    #region Page Functions
    public void ActivateDefaultPage(int defaultPageIndex)
    {
        GoToPage(defaultPageIndex);
    }
    public void GoToPage(int pageIndex)
    {
        if (pageIndex < pages.Count && pages[pageIndex] != null)
        {
            SetAllPages(false);
            pages[pageIndex].SetActive(true);
        }
    }

    public void SetAllPages(bool activate)
    {
        for (int i = 0; i < pages.Count; i++)
        {
            pages[i].SetActive(activate);
        }
    }
    #endregion

    #region Creating UI Effects
    public void CreateHoverEffect()
    {
        if (onHoverEffect != null && uICloneFolder != null)
        {
            Instantiate(onHoverEffect, uICloneFolder.transform);
        }
    }
    public void CreateClickEffect()
    {
        if (clickEffect != null && uICloneFolder != null)
        {
            Instantiate(clickEffect, uICloneFolder.transform);
        }
    }
        public void CreateBackClickEffect()
    {
        if (backClickEffect != null && uICloneFolder != null)
        {
            Instantiate(backClickEffect, uICloneFolder.transform);
        }
    }
    #endregion
}
