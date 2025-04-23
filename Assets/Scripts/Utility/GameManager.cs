/*=========================================================
 Author:     OU CSI 4380 provided code
 Description: Class which manages the game
==========================================================*/
using Mono.Cecil.Cil;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    // The global instance for other scripts to reference
    public static GameManager instance = null;

    [Header("References:")]
    [Tooltip("The UIManager component which manages the current scene's UI")]
    public UIManager uiManager = null;
    AudioSource levelMusic;

    [Header("Scores")]
    [Tooltip("The player's score")]
    [SerializeField] private int gameManagerScore = 0;

    // Static getter/setter for player score (for convenience)
    public static int score
    {
        get
        {
            return instance.gameManagerScore;
        }
        set
        {
            instance.gameManagerScore = value;
        }
    }

    [Tooltip("The highest score acheived on this device")]
    public int highScore = 0;

    [Header("Game Progress / Victory Settings")]
    [Tooltip("Whether the game is winnable or not \nDefault: true")]
    public bool gameIsWinnable = true;
    [Tooltip("Page index in the UIManager to go to on winning the game")]
    public int gameVictoryPageIndex = 0;
    [Tooltip("The effect to create upon winning the game")]
    public GameObject victoryEffect;

    /* <summary>
     Description:
     Standard Unity function called when this instance is first loaded (before start)
     Input: 
     none
     Return: 
     void (no return)
     </summary> */
    private void Awake()
    {
        // When this component is first added or activated, setup the global reference
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    /* <summary>
     Description:
     Standard Unity function called once before the first update
    Less urgent startup behaviors*/
    private void Start()
    {
        levelMusic = GetComponent<AudioSource>();
    }




    /* <summary>
     Description:
     Standard Unity function that gets called when the application (or playmode) ends
     Input:
     none
     Return:
     void (no return)
     </summary> */
    private void OnApplicationQuit()
    {
        SaveHighScore();
        ResetScore();
    }

    /* <summary>
     Description:
     Sends out a message to UI elements to update
     Input:
     none
     Return: 
     void (no return)
     </summary> */
    public static void UpdateUIElements()
    {
        if (instance != null && instance.uiManager != null)
        {
            instance.uiManager.UpdateUI();
        }
    }

    /* <summary>
     Description:
     Ends the level, meant to be called when the level is complete (End of level reached)
     Input: 
     none
     Return: 
     void (no return)
     </summary> */


    [Header("Game Over Settings:")]
    [Tooltip("The index in the UI manager of the game over page")]
    public int gameOverPageIndex = 0;
    [Tooltip("The game over effect to create when the game is lost")]
    public GameObject gameOverEffect;

    // Whether or not the game is over
    [HideInInspector]
    public bool gameIsOver = false;

    /* <summary>
     Description:
     Displays game over screen
     Input:
     none
     Return:
     void (no return)
     </summary> */
    public void GameOver()
    {
        gameIsOver = true;
        if (gameOverEffect != null)
        {
            Instantiate(gameOverEffect, transform.position, transform.rotation, null);
            Time.timeScale = 0;
            levelMusic.volume = 0.5f;
        }
        if (uiManager != null)
        {
            uiManager.allowPause = false;
            uiManager.GoToPage(gameOverPageIndex);
        }
    }

    /* <summary>
     Description:
     Adds a number to the player's score stored in the gameManager
     Input: 
     int scoreAmount
     Return: 
     void (no return)
     </summary> 
     <param name="scoreAmount">The amount to add to the score</param>*/
    public static void AddScore(int scoreAmount)
    {
        score += scoreAmount;
        if (score > instance.highScore)
        {
            SaveHighScore();
        }
        UpdateUIElements();
    }

    /* <summary>
     Description:
     Resets the current player score
     Input: 
     none
     Return: 
     void (no return)
     </summary> */
    public static void ResetScore()
    {
        PlayerPrefs.SetInt("score", 0);
        score = 0;
    }

    /* <summary>
     Description:
     Resets the game player prefs of the lives, health, and score
     Input:
     none
     Return:
     void (no return)
     </summary> */
    public static void ResetGamePlayerPrefs()
    {
        PlayerPrefs.SetInt("score", 0);
        score = 0;
        PlayerPrefs.SetInt("lives", 0);
        PlayerPrefs.SetInt("health", 0);
    }

    /* <summary>
     Description:
     Saves the player's highscore
     Input:
     none
     Return: 
     void (no return)
     </summary> */
    public static void SaveHighScore()
    {
        if (score > instance.highScore)
        {
            PlayerPrefs.SetInt("highscore", score);
            instance.highScore = score;
        }
        UpdateUIElements();
    }

    /* <summary>
     Description:
     Resets the high score in player preferences
     Input:
     none
     Returns: 
     void (no return)
     </summary> */
    public static void ResetHighScore()
    {
        PlayerPrefs.SetInt("highscore", 0);
        if (instance != null)
        {
            instance.highScore = 0;
        }
        UpdateUIElements();
    }
}
