using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BW : MonoBehaviour
{
    public Shader blackAndWhiteShader;

    void Start()
    {
        // Get all renderers in the scene
        Renderer[] renderers = FindObjectsOfType<Renderer>();

        // Iterate through each renderer
        foreach (Renderer renderer in renderers)
        {
            // Iterate through each material of the renderer
            for (int i = 0; i < renderer.sharedMaterials.Length; i++)
            {
                // Create a new material with the black and white shader
                Material newMaterial = new Material(blackAndWhiteShader);

                // Copy properties from the original material
                newMaterial.CopyPropertiesFromMaterial(renderer.sharedMaterials[i]);

                // Assign the new material to the renderer
                renderer.sharedMaterials[i] = newMaterial;
            }
        }
    }
}
