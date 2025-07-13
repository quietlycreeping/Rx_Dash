/*=========================================================
 Author:     J. Orlando
 Date:       April 2025
 Description: Scriptable object to hold customer data 
==========================================================*/
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CustomerData_SO", menuName = "Scriptable Objects/Characters/Customer Data")]
public class CustomerData_SO : ScriptableObject
{
    [Header("Bio")]
    public GameObject custPrefab;
    public string firstName;
    public string lastName;

    [Header("Birthday")]
    [Tooltip("1 to 12")]
    public int month;
    [Tooltip("1 to number of days in that month/year")]
    public int day;
    [Tooltip("1 to 9999")]
    public int year;

    [Header("Wait Tolerances")]
    /*Times will be added together to get total stay
    Example: Total time=15
    ╔═════════════╦═════╦═══════╦═════════╗
    ║   Variable  ║ Set ║ Range ║  State  ║
    ╠═════════════╬═════╬═══════╬═════════╣
    ║  quickWait  ║  5  ║  0-5  ║  HAPPY  ║
    ╠═════════════╬═════╬═══════╬═════════╣
    ║ averageWait ║  10 ║  6-15 ║ CONTENT ║
    ╠═════════════╬═════╬═══════╬═════════╣
    ║   maxWait   ║  5  ║ 16-20 ║  UPSET  ║
    ╠═════════════╩═════╬═══════╬═════════╣
    ║         -         ║  >15  ║  ANGRY  ║
    ╚═══════════════════╩═══════╩═════════╝
    */
    [Tooltip("Time customer will be extra happy (+points) to have their service be finished in.")]
    public int quickWait;
    [Tooltip("Time customer will be content to have the service be finished in.")]
    public int averageWait;
    [Tooltip("Last straw. Customer will leave at end of time and even if service is not done.")]
    public int maxWait;

    [Header("Drugs")]
    public int bagIdentifer;
    public List<ScriptableObject> medicine;
}
