/*=========================================================
 Author:     J. Orlando
 Date:       April 2025
 Description: Singleton to manage game logic
==========================================================*/
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TMPro.EditorUtilities;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(LevelStats))]
public class GameManager : GenericSingleton<GameManager>
{
//================= Events =================//

//================= Variables =================//
    [Header("Requirements")]
    public UIManager uIManager;
    [HideInInspector]
    public LevelStats levelStats;

    [Header("Win/Lose Stats")]
    public int winPageIndex = 0;
    public int losePageIndex = 0;

//================= Core Functions =================//
    protected override void Awake()
    {
        base.Awake();
        levelStats = GetComponent<LevelStats>();
    }


//================= Functions =================//
}
