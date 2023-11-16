using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroductionSript : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas introductionCanvas;
    public Canvas tutorialCanvas;
    public tutorailCamera tutorailCamera;
    void Start()
    {
        tutorialCanvas.enabled = true;
        tutorailCamera.startTutorial = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
