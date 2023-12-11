using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOnTrigger1 : MonoBehaviour
{
    public float fadeSpeed = 0.5f; // Speed at which the object fades
    public GameObject objectToFade; // Reference to the object you want to fade

    private Renderer objectRenderer;
    private bool isFading = false;

    void Start()
    {
        objectRenderer = objectToFade.GetComponent<Renderer>();

        if (objectRenderer == null)
        {
            Debug.LogError("Renderer component not found on the object to fade!");
            enabled = false;
            return;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isFading = true;
        }
    }

    void Update()
    {
        if (isFading)
        {
            // Get the current color of the material
            Color currentColor = objectRenderer.material.color;

            // Calculate the new alpha value with fading speed
            float newAlpha = Mathf.Clamp01(currentColor.a - fadeSpeed * Time.deltaTime);

            // Apply the new alpha value to the material color
            objectRenderer.material.color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);

            // If the alpha becomes zero, disable the script or the renderer
            if (newAlpha <= 0f)
            {
                if(newAlpha == 0f)
                {
                    Destroy(objectToFade);
                }
                // Disable the script or the renderer, depending on your needs
                // For example, you can disable the script:
                enabled = false;

                // Or you can disable the renderer:
                // objectRenderer.enabled = false;

                // Reset the flag so it doesn't keep fading
                isFading = false;
            }
        }
    }

}
