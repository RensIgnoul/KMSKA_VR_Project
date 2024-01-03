using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingCollisionZone : MonoBehaviour
{
    [SerializeField]
    private PaintingRandomizer Painting;
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
            Painting.ActiveRandomize = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Painting.ActiveRandomize = true;
        }
    }
}
