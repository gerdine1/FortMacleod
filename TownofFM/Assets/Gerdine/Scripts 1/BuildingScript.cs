using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScript : MonoBehaviour
{
    // List of objects to be enabled
    public List<GameObject> objectsToEnable;
    // Time interval between enabling objects
    public float interval = 3f;

    void Start()
    {
        StartCoroutine(EnableObjects());
    }

    IEnumerator EnableObjects()
    {
        foreach (GameObject obj in objectsToEnable)
        {
            obj.SetActive(true);
            yield return new WaitForSeconds(interval);
        }
    }
}