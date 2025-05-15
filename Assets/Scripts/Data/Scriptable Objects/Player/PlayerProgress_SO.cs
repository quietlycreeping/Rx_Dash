/*=========================================================
 Author:     J. Orlando
 Date:       May 2025
 Description: Scriptable object to hold player play data
==========================================================*/
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerProgress_SO", menuName = "Scriptable Objects/Characters/Player/Player Play Data")]
public class PlayerProgress_SO : ScriptableObject
{
    public PlayedLevelData[] playedLevelData;
}

[System.Serializable]
public struct PlayedLevelData
{
    public int starsEarned;
    public int scoreEarned;
}
