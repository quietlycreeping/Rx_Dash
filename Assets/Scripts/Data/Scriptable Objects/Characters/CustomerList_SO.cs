using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CustomerList_SO", menuName = "Scriptable Objects/Characters/List of Customers")]
public class CustomerList_SO : ScriptableObject
{
    public List<ScriptableObject> customerList;
}
