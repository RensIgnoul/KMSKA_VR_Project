using System.Collections;
using UnityEngine;

public class FirstCut : MonoBehaviour
{
    [SerializeField]
    private CameraAngle angle;

    /*[SerializeField]
    private GameObject testObject;*/

    [SerializeField]
    private GameObject newRoom;
    [SerializeField]
    private GameObject wall;
    public GameObject[] PhaseOneObjects;

    [SerializeField]
    private audio audioScript;

    // Start is called before the first frame update
    void Start()
    {
        //testObject.SetActive(false);
        newRoom.SetActive(false);
        audioScript.changeIfLoop(3, true);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            angle.triggerRay = true;
            Debug.Log("Player is in zone");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (angle.HandleRay()) //angle.y > -0.6341372 && angle.y < -0.3582904)
            {
                Debug.Log("Player is in zone and looking");
                //testObject.SetActive(true);
                newRoom.SetActive(true);
                wall.SetActive(true);
                PhaseOneObjects[0].SetActive(false);
                PhaseOneObjects[1].SetActive(false);
                audioScript.changeIfLoop(3, false);
                audioScript.PlaySecondBackgroundMusic();

            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            angle.triggerRay = false;
        }
    }


    
}
