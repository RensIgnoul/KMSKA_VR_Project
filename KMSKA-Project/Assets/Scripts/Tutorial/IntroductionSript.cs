using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class IntroductionSript : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas introductionCanvas;
    public TMP_Text text;
    public Canvas tutorialCanvas;
    public tutorailCamera tutorailCamera;
    public bool skipTutorial;
    private GameObject tutorialBlock;
    void Start()
    {
        tutorialBlock = GameObject.FindGameObjectWithTag("TutorialStart");
        if (skipTutorial)
        {
            tutorialCanvas.enabled = true;
            tutorailCamera.startTutorial = true;
            introductionCanvas.enabled = false;
        }
        else
        {
            tutorialCanvas.enabled = false;
            tutorailCamera.startTutorial = false;
            IntroFunction();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void IntroFunction()
    {
        text.text = "Welcome to the surreal world inspired by the life of James Ensor, the visionary artist who danced on the edge of reality and imagination. ";
        StartCoroutine(DisplayTextRoutine("Immerse yourself in the vibrant landscapes of his mind, where reality is distorted, and creativity knows no bounds.", 10f));
        StartCoroutine(DisplayTextRoutine("As you step into Ensor's universe, prepare to witness the convergence of art and emotion. Uncover the mysteries of his life, where masks conceal truths, and each stroke of the brush tells a tale. ", 20f));
        StartCoroutine(DisplayTextRoutine("This VR journey is a canvas of exploration, where the boundaries between reality and fantasy blur.", 30f));
        StartCoroutine(DisplayTextRoutine("Before you embark on this artistic adventure, let's guide you through the brushstrokes of VR interaction.", 40f));
        StartCoroutine(DisplayTextRoutine(" In the upcoming tutorial, you'll learn to navigate this immersive world, unlocking the secrets that lie beneath the surface.", 50f));
        StartCoroutine(DisplayTextRoutine("Get ready to paint your own story in the palette of Ensor's dreams. Your journey begins now!", 60f));
        StartCoroutine(DisplayTextRoutine("Look behind you to proceed the tutorial", 65f));
        Invoke("activateTutorial", 210f);


    }

    void activateTutorial()
    {
        tutorialCanvas.enabled = true;
        tutorailCamera.startTutorial = true;
        tutorialBlock.SetActive(true);
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
