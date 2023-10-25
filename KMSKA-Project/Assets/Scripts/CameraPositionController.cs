using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionController : MonoBehaviour
{
    [SerializeField]
    private GameObject XRRig;

    // Start is called before the first frame update
    void Start()
    {
        XRRig.transform.position = new Vector3(XRRig.transform.position.x, 0, XRRig.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        XRRig.transform.position = new Vector3(XRRig.transform.position.x, 0, XRRig.transform.position.y);
    }
}
