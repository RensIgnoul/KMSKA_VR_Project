using System.Collections;
using UnityEngine;

public class CameraFade : MonoBehaviour
{
    public Material targetMaterial;
    public float fadeDuration = 2.0f;  // Duration of the fade in seconds
    public bool fadeInOnStart = true;  // Whether to start fading in automatically

    private float currentAlpha = 0f;
    private float targetAlpha = 1f;
    private float startTime;

    void Start()
    {
       
        if (targetMaterial == null)
        {
            Debug.LogError("Target Material is not set!");
            return;
        }
        else
        {
            Debug.Log("material reset");
            SetMaterialAlpha(0f);
        }

        if (fadeInOnStart)
        {
            StartFadeIn();
        }
    }

    void Update()
    {
        // If fading is in progress, update the material's transparency
        if (startTime > 0f)
        {
            float elapsedTime = Time.time - startTime;
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);

            currentAlpha = Mathf.Lerp(0f, targetAlpha, t);
            SetMaterialAlpha(currentAlpha);

            // If the fade is complete, reset variables
            if (t == 1f)
            {
                startTime = 0f;
            }
        }
    }

    void SetMaterialAlpha(float alpha)
    {
        Color color = targetMaterial.color;
        color.a = alpha;
        targetMaterial.color = color;
    }

    public void StartFadeIn()
    {
        startTime = Time.time;
        currentAlpha = 0f;
        targetAlpha = 1f;
    }

    public void StartFadeOut()
    {
        startTime = Time.time;
        currentAlpha = 1f;
        targetAlpha = 0f;
    }
}
