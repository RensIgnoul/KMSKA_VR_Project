using UnityEngine;
using TMPro;
using System;
using System.Collections;

public class tutorailCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas canvas;
    public TMP_Text text;
    public bool startTutorial = false;
    private bool go1 = true;
    private bool go2 = true;
    private GameObject trigger1;
    private GameObject trigger2;
    private GameObject trigger3;
    [SerializeField]
    private MovementTutorial tutorialPartTwo;
    private bool activateRay = true;
    void Start()
    { 
        text.text = "";
        trigger1 = GameObject.FindGameObjectWithTag("TutorialTrigger1");
        trigger2 = GameObject.FindGameObjectWithTag("TutorialTrigger2");
        trigger3 = GameObject.FindGameObjectWithTag("TutorialTrigger3");
        trigger1.SetActive(false);
        trigger2.SetActive(false);
        trigger3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (activateRay)
        {
            lookAround();
        }

        if (tutorialPartTwo.activated == false && startTutorial)
        {
            if (text.text == "")
            {
                text.text = "Welcome to the tutorial";

                GameObject[] obj = { trigger1, trigger2 };
                StartCoroutine(DisplayTextRoutine("Start by looking at the two pilars, to your left and your right", 3f, obj));
            }
        }
        if (tutorialPartTwo.activated == false && startTutorial == false)
        {
            Debug.Log("starttutorial is false");
        }
    }

    private void lookAround()
    {

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, 200000f))
        {
            Debug.Log("Casting");
            if (hit.collider.CompareTag("TutorialTrigger1"))
            {
                hit.collider.gameObject.SetActive(false);
                Debug.Log("trigger 1 activated");
                go1 = false;
            }
            if (hit.collider.CompareTag("TutorialTrigger2"))
            {
                hit.collider.gameObject.SetActive(false);
                go2 = false;
            }
            if (hit.collider.CompareTag("TutorialStart"))
            {
                startTutorial = true;
                hit.collider.gameObject.SetActive(false);
                Debug.Log("tutorial start triggered");
            }

            //show text
            if (go1 == true && go2 == true)
            {

            }
            else if (go1 == true && go2 == false)
            {
                text.text = "look at the left pilar";
            }
            else if (go1 == false && go2 == true)
            {
                text.text = "look at the right pilar";
            }
            else
            {
                text.text = "Good Job!";
                StartCoroutine(DisplayTextRoutine("Walk towards the area", 1.5f));
                trigger3.SetActive(true);
                tutorialPartTwo.activated = true;
                activateRay = false;
                return;
            }
        }
    }
    IEnumerator DisplayTextRoutine(String newText, float displayTime = 3f, GameObject[] objects = null)
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

