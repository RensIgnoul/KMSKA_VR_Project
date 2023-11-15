using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MovementTutorial : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;
    public SceneController sceneController;

    [SerializeField]
    private TMP_Text text;
    public bool activated = false;
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
            Debug.Log("Finished tutorial");
            text.text = "Finished Tutorial";
            Invoke("changeScene", 2.0f);
        }
    }

    private void changeScene()
    {
        sceneController.changeScene();
    }
}
