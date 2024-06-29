using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableFire : MonoBehaviour
{
    public GameObject[] objectsToEnable; // Array of objects to enable
    public float delayBetweenObjects = 2f; // Delay between enabling each object
    private int currentIndex = 0; // Index of the current object to enable

    public AudioSource[] soundsToEnable; // Array of AudioSources for the sound effects to enable
    public AudioSource[] soundsToDisable; // Array of AudioSources for the sound effects to disable

    void Start()
    {
        Invoke("EnableNextObject", delayBetweenObjects); // Invoke EnableNextObject method after the initial delay
        Invoke("ManageSoundEffects", delayBetweenObjects); // Invoke ManageSoundEffects method after the initial delay
    }

    void EnableNextObject()
    {
        if (currentIndex < objectsToEnable.Length)
        {
            GameObject obj = objectsToEnable[currentIndex];
            obj.SetActive(true); // Enable the current object

            AudioSource audioSource = obj.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Play(); // Play the sound effect if AudioSource is attached
            }

            currentIndex++; // Increment the index
            Invoke("EnableNextObject", delayBetweenObjects); // Invoke EnableNextObject method again after the delay
        }
    }

    void ManageSoundEffects()
    {
        if (soundsToEnable.Length > 0)
        {
            // Enable the first sound effect after a delay
            AudioSource firstSound = soundsToEnable[0];
            if (firstSound != null)
            {
                firstSound.PlayDelayed(delayBetweenObjects);
            }

            // Enable the second sound effect after a delay
            if (soundsToEnable.Length > 1)
            {
                AudioSource secondSound = soundsToEnable[1];
                if (secondSound != null)
                {
                    secondSound.PlayDelayed(delayBetweenObjects * 2); // Double the delay for the second sound
                }
            }
        }

        // Disable all sound effects in soundsToDisable (if needed)
        foreach (AudioSource sound in soundsToDisable)
        {
            if (sound != null && sound.isPlaying)
            {
                sound.Stop(); // Disable the sound effect
            }
        }
    }
}