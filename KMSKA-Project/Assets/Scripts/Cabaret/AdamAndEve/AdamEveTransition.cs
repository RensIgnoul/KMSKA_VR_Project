using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdamEveTransition : MonoBehaviour
{


    [SerializeField]// Start is called before the first frame update
    private GameObject[] objectsToDissapear;

    [SerializeField]
    private CameraAngle angle;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (angle.HandleRay())
            {
                Debug.Log("Player is in zone and looking");
                foreach (var item in objectsToDissapear)
                {
                    item.SetActive(false);
                }
            }
        }
    }
}
