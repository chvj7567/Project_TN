using System;
using UnityEngine;

public class SingletoneMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    private static object _lock = new object();
    private static bool applicationIsQuitting = false;

    protected static Action OnQuit;

    public static T Instance
    {
        get
        {
            if (applicationIsQuitting)
            {
                return null;
            }

            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = (T)FindAnyObjectByType(typeof(T));

                    if (_instance == null)
                    {
                        GameObject obj = new GameObject();
                        _instance = obj.AddComponent(typeof(T)) as T;
                        obj.name = typeof(T).ToString();

                        DontDestroyOnLoad(obj);
                    }
                }

                return _instance;
            }
        }
    }

    public void OnDestroy()
    {
        OnQuit?.Invoke();
        applicationIsQuitting = true;
    }
}
