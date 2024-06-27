using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Base class for managing game scenes and logging start events
public class BaseManager : MonoBehaviour
{
    // Called when the object is started
    protected virtual void Start()
    {
        // Log a message indicating the type of manager started
        Debug.Log($"{this.GetType().Name} started.");
    }

    // Method to load a scene by name
    protected virtual void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);   // Load the specified scene using Unity's SceneManager
    }
}
