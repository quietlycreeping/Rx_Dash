using UnityEngine;

public class BaggedScript : MonoBehaviour, IClickable
{
    public void Interact()
    {
        Debug.Log("drug clicked");
    }
}
