using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCut : MonoBehaviour
{
    [SerializeField]
    private CameraAngle angle;

    /*[SerializeField]
    private GameObject testObject;*/

    [SerializeField]
    private GameObject newRoom;
    public GameObject[] PhaseOneObjects;
    // Start is called before the first frame update
    void Start()
    {
        //testObject.SetActive(false);
        newRoom.SetActive(false);
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
                PhaseOneObjects[0].SetActive(false);
                PhaseOneObjects[1].SetActive(false);
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

    private void ToggleDoors()
    {
        for (int i = 0; i < PhaseOneObjects.Length; i++)
        {
            if (PhaseOneObjects[i].activeSelf == true)
            {
                PhaseOneObjects[i].SetActive(false);
            }
            else
            {
                PhaseOneObjects[i].SetActive(true);
            }
        }
    }
}
