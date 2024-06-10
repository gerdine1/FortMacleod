using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCanvas : MonoBehaviour

{
    // Reference to the first canvas GameObject
    public GameObject canvas;

    // Reference to the second canvas GameObject
    public GameObject secondCanvas;

    // Delay in seconds before enabling the second canvas
    public float delay = 10f;

    // This function is called when the player enters the trigger zone
    void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger zone is the player
        if (other.CompareTag("Player"))
        {
            // Enable the first canvas
            canvas.SetActive(true);

            // Invoke EnableSecondCanvas method after the delay
            Invoke("EnableSecondCanvas", delay);
        }
    }

    // This function is called when the player exits the trigger zone (optional)
    void OnTriggerExit(Collider other)
    {
        // Check if the object that exited the trigger zone is the player
        if (other.CompareTag("Player"))
        {
            // Optionally, disable the first canvas when the player exits the trigger
            canvas.SetActive(false);
        }
    }

    // Method to enable the second canvas
    private void EnableSecondCanvas()
    {
        if (secondCanvas != null)
        {
            // Enable the second canvas
            secondCanvas.SetActive(true);
        }
    }
}