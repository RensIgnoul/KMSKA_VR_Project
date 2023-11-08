using UnityEngine;
using TMPro;
using System;

public class tutorailCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas canvas;
    public TMP_Text text;
    private bool go1 = true;
    private bool go2 = true;
    private GameObject trigger3;
    [SerializeField]
    private MovementTutorial tutorialPartTwo;
    void Start()
    {
        text.text = "Look at the two nodes";
        trigger3 = GameObject.FindGameObjectWithTag("TutorialTrigger3");
        trigger3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        lookAround();
    }

    public void lookAround()
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

            //show text
            if (go1 == true && go2 == true)
            {
                text.text = "Look at the two nodes";
            }
            else if (go1 == true && go2 == false)
            {
                text.text = "look at the left node";
            }
            else if (go1 == false && go2 == true)
            {
                text.text = "look at the right node";
            }
            else
            {
                text.text = "Congratulations!";
                trigger3.SetActive(true);
                tutorialPartTwo.activated = true;
            }
        }
    }

    public void move()
    {
        trigger3.SetActive(true);
        text.text = "walk towards the platform";


    }
}
