using UnityEngine;

public class GenericSingleton<T> : MonoBehaviour where T: GenericSingleton<T> //generic singleton
{
    private static T instance;

    public static T Instance
    { get {return instance;}}

    protected virtual void Awake ()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = (T)this;
    }

    public static bool IsInitialized
    { get {return instance != null;}}

    protected virtual private void OnDestroy()
    {
        if (instance == this)
        { instance = null;}
    }
}

