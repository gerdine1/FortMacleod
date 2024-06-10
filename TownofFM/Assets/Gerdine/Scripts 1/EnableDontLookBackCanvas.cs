using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDontLookBackCanvas : MonoBehaviour
{
    // Reference to the Canvas you want to enable
    public Canvas targetCanvas;

    // Delay time in seconds
    public float delay = 6.0f;

    // This function is called when the script instance is being loaded
    void OnEnable()
    {
        // Start the coroutine to enable the target canvas after a delay
        StartCoroutine(EnableCanvasWithDelay());
    }

    private IEnumerator EnableCanvasWithDelay()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(delay);

        // Enable the target Canvas
        targetCanvas.gameObject.SetActive(true);
    }
}
