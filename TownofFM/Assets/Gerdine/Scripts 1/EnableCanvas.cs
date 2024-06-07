using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCanvas : MonoBehaviour
{
    public GameObject canvas; // Reference to the first canvas GameObject
    public GameObject secondCanvas; // Reference to the second canvas GameObject
    public float delay = 10f; // Delay in seconds before enabling the second canvas

    public void EnableCanvas()
    {
        canvas.SetActive(true); // Enable the first canvas
        Invoke("EnableSecondCanvas", delay); // Invoke EnableSecondCanvas method after the delay
    }

    private void EnableSecondCanvas()
    {
        if (secondCanvas != null)
        {
            secondCanvas.SetActive(true); // Enable the second canvas
        }
    }
}
