using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Honk : MonoBehaviour
{
    public AudioClip audioClip; // Audio clip to play
    public float interval = 50f; // Interval in seconds between each play

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Start the coroutine to play the audio clip at intervals
        StartCoroutine(PlayAudioAtInterval());
    }

    IEnumerator PlayAudioAtInterval()
    {
        while (true)
        {
            // Wait for the specified interval
            yield return new WaitForSeconds(interval);

            // Check if audio clip is assigned and play it
            if (audioClip != null && audioSource != null)
            {
                audioSource.clip = audioClip;
                audioSource.Play();
            }
        }
    }
}