using UnityEngine;

[CreateAssetMenu(fileName = "ScoreData_SO", menuName = "Scriptable Objects/ScoreModifer_SO")]
public class ScoreData_SO : ScriptableObject
{
    [Header("Per Second Point Vaule")]
    public float earlyFinishMod;
    public float averageFinishMod;
    public float lateFinishMod;

    [Header("Set Points")]
    public int missScore;
}
