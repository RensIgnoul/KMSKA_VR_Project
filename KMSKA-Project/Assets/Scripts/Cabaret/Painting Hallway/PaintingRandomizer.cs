using System.Collections;
using UnityEngine;

public class PaintingRandomizer : MonoBehaviour
{
    public bool ActiveRandomize;
    void Start()
    {
        ActiveRandomize = true;
        InvokeRepeating("RandomizePaintings", 1f, 2f);
    }

    void Update()
    {


    }
    void RandomizePaintings()
    {
        if (ActiveRandomize)
        {
            int rng = Random.Range(0, 2);
            Debug.Log(rng);
            if (rng == 0)
            {
                if (gameObject.activeSelf)
                {
                    gameObject.SetActive(false);
                    Debug.Log("IS NOT ACTIVE");
                }
                else
                {
                    gameObject.SetActive(true);
                    Debug.Log("IS ACTIVE");
                }
            }
        }
    }
}
