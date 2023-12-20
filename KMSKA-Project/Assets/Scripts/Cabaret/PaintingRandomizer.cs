using System.Collections;
using UnityEngine;

public class PaintingRandomizer : MonoBehaviour
{
    [SerializeField]
    private GameObject[] paintings;

    private bool[] paintingsActive;

    void Start()
    {
        paintingsActive = new bool[paintings.Length];
        for (int i = 0; i < paintingsActive.Length; i++)
        {
            paintingsActive[i] = false;
        }
        //InvokeRepeating("RandomizePaintings", 0f, 2f);
    }

    void Update()
    {


    }
    IEnumerator RandomizePaintings()
    {
        while (true)
        {
            foreach (var painting in paintings)
            {
                var rng = Random.Range(0, 2);
                if (rng == 0)
                {
                    painting.SetActive(false);
                }
                else
                {
                    painting.SetActive(true);
                }
            }
            yield return new WaitForSeconds(2f);
        }
    }
}
