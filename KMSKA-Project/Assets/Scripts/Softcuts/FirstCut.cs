using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCut : MonoBehaviour
{
    [SerializeField]
    private CameraAngle angle;

    [SerializeField]
    private GameObject testObject;

    [SerializeField]
    private GameObject newRoom;
    public GameObject[] Doors;
    // Start is called before the first frame update
    void Start()
    {
        testObject.SetActive(false);
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
            Debug.Log("Player is in zone");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(angle.y > -0.6341372 && angle.y < -0.3582904)
            {
                Debug.Log("Player is in zone and looking");
                testObject.SetActive(true);
                newRoom.SetActive(true);
                Doors[0].SetActive(true);
                Doors[1].SetActive(false);
            }
        }
    }

    private void ToggleDoors()
    {
        for (int i = 0; i < Doors.Length; i++)
        {
            if (Doors[i].activeSelf == true)
            {
                Doors[i].SetActive(false);
            }
            else
            {
                Doors[i].SetActive(true);
            }
        }
    }
}
