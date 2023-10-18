using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAngle : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTransform;
    public float x;
    public float y;
    public float z;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraTransform == null)
        {
            Debug.LogError("Camera Transform is not assigned.");
            return;
        }
        else
        {
            //Debug.Log($"X: {cameraTransform.rotation.x} Y: {cameraTransform.rotation.y} Z: {cameraTransform.rotation.y}");
        }
        x = cameraTransform.rotation.x;
        y = cameraTransform.rotation.y;
        z = cameraTransform.rotation.z;

    }
}
