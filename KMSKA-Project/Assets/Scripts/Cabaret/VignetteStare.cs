using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VignetteStare : MonoBehaviour
{
    public Volume postProcessingVolume;
    private Vignette vignetteLayer;

    public float maxVignetteIntensity = 1f;
    public float duration = 2f; // Duration in seconds

    private float currentDuration = 0f;

    private void Start()
    {
        postProcessingVolume.profile.TryGet(out vignetteLayer);

        if (vignetteLayer != null)
        {
            vignetteLayer.intensity.value = 0f;
        }
    }

    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        int triggerLayer = LayerMask.GetMask("Painting1Layer");
        if (Physics.Raycast(ray, out hit, 200f, triggerLayer))
        {

            if (hit.collider.CompareTag("Trigger1"))
            {
                Debug.Log("hit trigger");
                if (vignetteLayer != null)
                {
                    if (currentDuration < duration)
                    {
                        currentDuration += Time.deltaTime;
                        float t = Mathf.Clamp01(currentDuration / duration);
                        vignetteLayer.intensity.value = Mathf.Lerp(0f, maxVignetteIntensity, t);
                    }
                    else
                    {
                        vignetteLayer.intensity.value = maxVignetteIntensity;
                    }
                }
            }
            else
            {
                // Gradually decrease the intensity when not looking at the specific object
                if (currentDuration > 0f)
                {
                    currentDuration -= Time.deltaTime;
                    float t = Mathf.Clamp01(currentDuration / duration);
                    vignetteLayer.intensity.value = Mathf.Lerp(0f, maxVignetteIntensity, t);
                }
                else
                {
                    // Reset vignette when duration is 0
                    vignetteLayer.intensity.value = 0f;
                }
            }

        }
        else
        {
            // Gradually decrease the intensity when not hitting anything
            if (currentDuration > 0f)
            {
                currentDuration -= Time.deltaTime;
                float t = Mathf.Clamp01(currentDuration / duration);
                vignetteLayer.intensity.value = Mathf.Lerp(0f, maxVignetteIntensity, t);
            }
            else
            {
                // Reset vignette when duration is 0
                vignetteLayer.intensity.value = 0f;
            }
        }

    }
}
