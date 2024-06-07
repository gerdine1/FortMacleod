using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeTitlePage : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeDuration = 5.0f;

    void Start()
    {
        // Start the coroutine to fade out the canvas
        StartCoroutine(FadeOutCanvas());
    }

    IEnumerator FadeOutCanvas()
    {
        float startAlpha = canvasGroup.alpha;
        float rate = 1.0f / fadeDuration;
        float progress = 0.0f;

        while (progress < 1.0f)
        {
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0, progress);
            progress += rate * Time.deltaTime;

            yield return null;
        }

        canvasGroup.alpha = 0;
    }
}
