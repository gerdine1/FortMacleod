using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // The name of the scene to load
    public string sceneName;

    // This function is called when the player enters the trigger zone
    void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger zone is the player
        if (other.CompareTag("Player"))
        {
            // Load the specified scene
            SceneManager.LoadScene(sceneName);
        }
    }
}
