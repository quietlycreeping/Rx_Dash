/*=========================================================
 Author:     J. Orlando + Class Content
 Date:       May 2025
 Description: Tool to destroy a GameObject after set time
==========================================================*/
using UnityEngine;

public class TimedObjectDestroy : MonoBehaviour
{
//================= Variables =================//
    [Header("Settings")]
    public float lifeTime = 5f;
    float timeAlive;
    public bool destroyChildrenOnDeath = true;

    [HideInInspector]
    public static bool quitting = false;

//================= Core Functions =================//
    void Update()
    {
        if (timeAlive > lifeTime)
        {
            Destroy(gameObject);
        }
        else
        {
            timeAlive += Time.deltaTime;
        }
    }

//================= Functions =================//
    private void OnApplicationQuit()
    {
        quitting = true;
        DestroyImmediate(gameObject);
    }
    
    private void OnDestroy()
    {
        if (destroyChildrenOnDeath && !quitting && Application.isPlaying)
        {
            int childCount = transform.childCount;
            for (int i = childCount - 1; i >= 0; i--)
            {
                GameObject childObject = transform.GetChild(i).gameObject;
                if (childObject != null)
                {
                    Destroy(childObject);
                }
            }
        }
        transform.DetachChildren();
    }
}
