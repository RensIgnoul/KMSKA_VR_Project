using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public GameObject obj;
    public GameObject[] pathPoints;
    public int numberOfPoints;
    public float speed;

    public bool StartPath;

    private Vector3 actualPosition;
    private int x;
    void Start()
    {
        x = 1;
        StartPath = false;
    }

    void Update()
    {
        actualPosition = obj.transform.position;
        if (StartPath)
        {
            obj.transform.position = Vector3.MoveTowards(actualPosition, pathPoints[x].transform.position, speed * Time.deltaTime);

            if (actualPosition == pathPoints[x].transform.position && x != numberOfPoints - 1)
            {
                x++;
            }
        }
        
    }
}
