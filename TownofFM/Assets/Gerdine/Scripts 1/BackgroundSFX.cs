using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioClipInfo
{
    public AudioClip clip; // The audio clip
    [Range(0f, 1f)]
    public float volume = 1.0f; // Volume for this audio clip
}

public class BackgroundSFX : MonoBehaviour
{
    public List<AudioClipInfo> audioClips; // List to hold multiple audio clips and their volume settings

    void Start()
    {
        foreach (AudioClipInfo clipInfo in audioClips)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = clipInfo.clip;
            audioSource.volume = clipInfo.volume;
            audioSource.Play();
        }
    }
}