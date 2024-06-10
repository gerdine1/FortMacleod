using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradualAppearanceManager : MonoBehaviour
{
    public List<GameObject> structures;
    public float appearDuration = 2.0f; // Duration of the appearance effect
    public float delayBetweenStructures = 0.5f; // Delay between the appearance of each structure
    public float heightOffset = 1.0f; // Height offset between parts of the structure

    private float startHeight; // Starting height for the appearance

    void Start()
    {
        // Set all structures to be inactive at the beginning
        foreach (GameObject structure in structures)
        {
            structure.SetActive(false);
        }

        // Start the DelayedAppear coroutine after a delay of 6 seconds
        StartCoroutine(DelayedAppear());
    }

    IEnumerator DelayedAppear()
    {
        // Wait for 6 seconds before starting the appearance
        yield return new WaitForSeconds(6f);

        // Get the y-position of the "ground" plane
        startHeight = transform.position.y;

        // Start the AppearStructures coroutine
        StartCoroutine(AppearStructures());
    }

    IEnumerator AppearStructures()
    {
        foreach (GameObject structure in structures)
        {
            structure.SetActive(true); // Activate the structure before fading it in
            StartCoroutine(Appear(structure));
            yield return new WaitForSeconds(delayBetweenStructures);
        }

        // Change shader or material properties after all structures have appeared
        yield return new WaitForSeconds(delayBetweenStructures); // Adding a delay for safety
        Debug.Log("All structures have appeared. Changing material rendering mode to opaque.");
        ChangeMaterialRenderingMode();
    }

    IEnumerator Appear(GameObject structure)
    {
        float elapsedTime = 0;

        // Get all renderers in the structure and its children recursively
        Renderer[] renderers = structure.GetComponentsInChildren<Renderer>(true);
        Dictionary<Renderer, Material[]> initialMaterials = new Dictionary<Renderer, Material[]>();

        foreach (Renderer renderer in renderers)
        {
            initialMaterials[renderer] = renderer.materials;
            foreach (Material material in initialMaterials[renderer])
            {
                if (!material.HasProperty("_Color"))
                {
                    Debug.LogWarning($"Material '{material.name}' on '{structure.name}' does not have a color property.");
                }
            }
        }

        while (elapsedTime < appearDuration)
        {
            foreach (Renderer renderer in renderers)
            {
                foreach (Material material in initialMaterials[renderer])
                {
                    if (material.HasProperty("_Color"))
                    {
                        Color currentColor = material.color;
                        currentColor.a = Mathf.Lerp(0, 1, elapsedTime / appearDuration);
                        material.color = currentColor;
                    }
                    else
                    {
                        // Handle materials without a color property (e.g., adjusting alpha via shader properties)
                        // Example: material.SetFloat("_Alpha", Mathf.Lerp(0, 1, elapsedTime / appearDuration));
                    }
                }
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Set the final color after the fade-in
        foreach (Renderer renderer in renderers)
        {
            foreach (Material material in initialMaterials[renderer])
            {
                if (material.HasProperty("_Color"))
                {
                    Color finalColor = material.color;
                    finalColor.a = 1;
                    material.color = finalColor;
                }
            }
        }
    }

    void ChangeMaterialRenderingMode()
    {
        foreach (GameObject structure in structures)
        {
            Renderer[] renderers = structure.GetComponentsInChildren<Renderer>(true);
            foreach (Renderer renderer in renderers)
            {
                Material material = renderer.material;
                material.SetFloat("_Mode", 0); // Change rendering mode to opaque
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                material.SetInt("_ZWrite", 1);
                material.DisableKeyword("_ALPHATEST_ON");
                material.DisableKeyword("_ALPHABLEND_ON");
                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = -1;
            }
        }
    }
}