using UnityEngine;

public class TimeManager : MonoBehaviour
{
//================= Variables =================//
    public static float time = 0f;

//================= Core Functions =================//
    public void Update()
    {
        time += Time.deltaTime;
        //Debug.Log(time);
    }
}
