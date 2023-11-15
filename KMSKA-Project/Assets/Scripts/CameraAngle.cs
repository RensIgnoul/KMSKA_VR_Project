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
    public bool triggerRay = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (triggerRay)
        {
            Debug.Log("triggered");
        }
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
        Debug.DrawRay(transform.position, transform.forward * 20);

    }
    public bool HandleRay()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 200f) && triggerRay)
        {
            if (hit.collider.CompareTag("Trigger1") || hit.collider.CompareTag("Trigger2"))
            {
                Debug.Log("Test");
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }
}

