using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class endScript : MonoBehaviour
{
    private GameObject hats;
    public Light spot;
    private CameraFade fade;
    public Canvas endcanvas;
    public TMP_Text text;
    public GameObject door;
    public GameObject door2;
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

    private void OnTriggerEnter(Collider other)
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

    }

    IEnumerator wait(float displayTime = 0.5f)
    {
        yield return new WaitForSeconds(displayTime);
        endcanvas.enabled = true;
        door.SetActive(false);
        door2.SetActive(true);
        text.text = "Born on April 13, 1860, in Ostend, Belgium, James Ensor lived through a dynamic period in art history, contributing significantly to the development of Expressionism. His masterful use of color, grotesque imagery, and a deep exploration of human psychology mark his legacy as one of the pioneers of modern art.";
        StartCoroutine(DisplayTextRoutine("He passed away on November 19, 1949, at the age of 89. Making 2024 the year we celebrate 75 years since his passing, a tribute to his enduring legacy.", 30f));
    }


    IEnumerator DisplayTextRoutine(string newText = "", float displayTime = 3f, GameObject[] objects = null)
    {
        yield return new WaitForSeconds(displayTime);
        if (objects != null)
        {
            foreach (var item in objects)
            {
                item.SetActive(true);
            }
        }
        text.text = newText;
    }
}

