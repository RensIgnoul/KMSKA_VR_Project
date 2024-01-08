using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondCut : MonoBehaviour
{
    [SerializeField]
    private CameraAngle angle;

    [SerializeField]
    private GameObject newRoom;
    [SerializeField]
    private GameObject[] PhaseThreeRoom;

    public GameObject painting;
    // Start is called before the first frame update
    void Start()
    {
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
            if (angle.HandleRay())
            {
                Debug.Log("Player is in zone and looking");
                newRoom.SetActive(true);
                foreach (var item in PhaseThreeRoom)
                {
                    if (item != null)
                    {
                        item.SetActive(false);
                    }
                }
                Destroy(painting);
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
