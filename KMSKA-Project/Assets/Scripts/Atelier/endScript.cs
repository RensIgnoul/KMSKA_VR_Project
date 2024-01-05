using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endScript : MonoBehaviour
{
    private GameObject hats;
    public Light spot;
    private CameraFade fade;
    // Start is called before the first frame update
    void Start()
    {
        hats = GameObject.FindWithTag("Hats");
        if (hats != null)
        {
            hats.SetActive(false);
            spot.enabled = false;
            showHats();
        }
        else
        {
            Debug.LogError("Hats not found");
        }
        fade = GetComponent<CameraFade>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            quit();
        }
    }
    private void showHats()
    {
        StartCoroutine(wait(15f));
        hats.SetActive(true);
        spot.enabled = true;
    }

    private void quit()
    {
        if (fade != null)
        {
            fade.fadeDuration = 5f;
            StartCoroutine(wait(fade.fadeDuration));
        }
        Application.Quit();
    }

    IEnumerator wait(float displayTime = 3f)
    {
        yield return new WaitForSeconds(displayTime);
    }
}
