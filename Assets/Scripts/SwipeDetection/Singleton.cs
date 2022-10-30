using System;
using Unity.VisualScripting;
using UnityEngine;

namespace SwipeDetection
{
    public class Singleton<T>: MonoBehaviour  where T : Component
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    var objects = FindObjectsOfType(typeof(T)) as T[];
                    if (objects.Length > 0)
                    {
                        _instance = objects[0];
                    }

                    if (objects.Length > 1)
                    {
                        Debug.LogError("There is more than one " + typeof(T).Name + " in the scene.");
                    }

                    if (_instance == null)
                    {
                        GameObject gameObject = new GameObject();
                        gameObject.hideFlags = HideFlags.HideAndDontSave;
                        _instance = gameObject.AddComponent<T>();
                    }
                }

                return _instance;
            }
        }
    }

    public class SingletonPersistent<T> : MonoBehaviour  where T : Component
    {
        public static T Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this as T;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}