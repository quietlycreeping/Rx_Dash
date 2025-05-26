using UnityEngine;

[CreateAssetMenu(fileName = "MedicineData_SO", menuName = "Scriptable Objects/Items/Medicine Data")]
public class MedicineData_SO : ScriptableObject
{
    [Header("Name")]
    public string brandName;
    public string genericName;

    [Header("...")]
    [TextArea]
    public string description;
    public string classNum;
    //TODO: change to enum?
}
