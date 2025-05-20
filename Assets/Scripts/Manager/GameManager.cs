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


public class GameManager : GenericSingleton<GameManager>
{
    //================= Events =================//

    //================= Variables =================//
    [Header("Requirements")]
    public UIManager uIManager;
    LevelStats levelStats;
    
    //================= Core Functions =================//
    protected override void Awake()
    {
        base.Awake();

        levelStats = GetComponent<LevelStats>();
    }


    //================= Functions =================//
}
