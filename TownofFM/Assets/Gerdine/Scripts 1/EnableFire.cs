using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableFire : MonoBehaviour
{
    public GameObject[] objectsToEnable; // Array of objects to enable
    public float delayBetweenObjects = 2f; // Delay between enabling each object
    private Light directionalLight; // Reference to the directional light
    private int currentIndex = 0; // Index of the current object to enable

    void Start()
    {
        directionalLight = FindObjectOfType<Light>(); // Find the directional light in the scene
        Invoke("EnableNextObject", delayBetweenObjects); // Invoke EnableNextObject method after the initial delay
        Invoke("MakeSceneDarker", delayBetweenObjects); // Invoke MakeSceneDarker method after the initial delay
    }

    void EnableNextObject()
    {
        if (currentIndex < objectsToEnable.Length)
        {
            objectsToEnable[currentIndex].SetActive(true); // Enable the current object
            currentIndex++; // Increment the index
            Invoke("EnableNextObject", delayBetweenObjects); // Invoke EnableNextObject method again after the delay
        }
    }

    void MakeSceneDarker()
    {
        if (directionalLight != null)
        {
            directionalLight.intensity = 0.5f; // Set the intensity of the directional light to make the scene darker
            directionalLight.color = Color.gray; // Optionally, change the color of the light to gray for a darker effect
        }
    }
}