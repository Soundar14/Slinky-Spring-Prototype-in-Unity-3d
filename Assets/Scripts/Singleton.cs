using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;

    public static T Instance
    {
        get
        {
            // If the instance is already set, return it
            if (instance != null)
                return instance;

            // Otherwise, try to find the existing instance in the scene
            instance = FindObjectOfType<T>();

            // If no instance exists, create a new one
            if (instance == null)
            {
                // Create an empty GameObject with the same name as the type
                GameObject singletonObject = new GameObject(typeof(T).Name);
                // Add the component to the singleton object
                instance = singletonObject.AddComponent<T>();
            }

            // Make sure the instance persists across scene changes
            DontDestroyOnLoad(instance.gameObject);

            return instance;
        }
    }

    protected virtual void Awake()
    {
        // Enforce the singleton pattern by checking if an instance already exists
        if (instance != null && instance != this)
        {
            // If an instance already exists and it's not this one, destroy this instance
            Destroy(gameObject);
        }
        else
        {
            // Set the instance if it hasn't been set yet
            instance = (T)this;
        }
    }
}
