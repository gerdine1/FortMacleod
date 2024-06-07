using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableFire : MonoBehaviour
{
    public GameObject[] objectsToEnable; // Array of objects to enable
    public float delayBetweenObjects = 2f; // Delay between enabling each object
    private Light directionalLight; // Reference to the directional light

    void Start()
    {
        directionalLight = FindObjectOfType<Light>(); // Find the directional light in the scene
        Invoke("EnableNextObject", delayBetweenObjects); // Invoke EnableNextObject method after the initial delay
        Invoke("MakeSceneDarker", delayBetweenObjects); // Invoke MakeSceneDarker method after the initial delay
    }

    void EnableNextObject()
    {
        foreach (GameObject obj in objectsToEnable)
        {
            obj.SetActive(true); // Enable the next object in the array
            Invoke("EnableNextObject", delayBetweenObjects); // Invoke EnableNextObject method again after the delay
            break; // Exit the loop after enabling one object
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