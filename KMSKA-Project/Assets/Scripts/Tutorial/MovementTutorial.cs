using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MovementTutorial : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;
    public SceneController sceneController;
    public CameraFade fade;

    [SerializeField]
    private TMP_Text text;
    public bool activated = false;
    public float transitionLength = 5f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            this.gameObject.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && activated)
        {
            //Debug.Log("Finished tutorial");
            text.text = "Finished Tutorial";
            fade.StartFadeIn();
            Invoke("changeScene", transitionLength);
        }
        else
        {
            //Debug.Log("ERR0R in OnTrigger event");
        }
    }

    private void changeScene()
    {
        sceneController.changeScene();
    }
}
