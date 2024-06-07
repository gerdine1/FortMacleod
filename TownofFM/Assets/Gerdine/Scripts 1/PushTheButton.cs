using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonVR : MonoBehaviour

{
    public GameObject button;
    public UnityEvent OnPress;
    public UnityEvent OnRelease;
    private GameObject presser;
    private AudioSource sound;
    private bool isPressed;
    public KeyCode testKey = KeyCode.Space; // Key to simulate the button press

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        isPressed = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(testKey) && !isPressed)
        {
            SimulateButtonPress();
        }
        else if (Input.GetKeyUp(testKey) && isPressed)
        {
            SimulateButtonRelease();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            SimulateButtonPress();
            presser = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            SimulateButtonRelease();
        }
    }

    private void SimulateButtonPress()
    {
        button.transform.localPosition = new Vector3(0, 0.003f, 0);
        OnPress.Invoke();
        sound.Play();
        isPressed = true;
    }

    private void SimulateButtonRelease()
    {
        button.transform.localPosition = new Vector3(0, 0.015f, 0);
        OnRelease.Invoke();
        isPressed = false;
    }
}





/*
{
    public GameObject button;
    public UnityEvent OnPress;
    public UnityEvent OnRelease;
    private GameObject presser;
    private AudioSource sound;
    private bool isPressed;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            button.transform.localPosition = new Vector3(0, 0.003f, 0);
            presser = other.gameObject;
            OnPress.Invoke();
            sound.Play();
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            button.transform.localPosition = new Vector3(0, 0.015f, 0);
            OnRelease.Invoke();
            isPressed = false;
        }
    }
}*/