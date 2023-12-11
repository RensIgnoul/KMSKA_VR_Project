using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{

    public float movementSpeedMultiplier = 2f;
    public Camera viewCamera;
    private Vector3 oldPosition;
    // Start is called before the first frame update
    void Start()
    {
        oldPosition = viewCamera.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 positionDifference = viewCamera.transform.localPosition - oldPosition;

        positionDifference.x *= movementSpeedMultiplier;
        positionDifference.z *= movementSpeedMultiplier;
        viewCamera.transform.localPosition = positionDifference;

        oldPosition = positionDifference;
        
    }
}
