using UnityEngine;

public class StartingScript : MonoBehaviour
{
    [SerializeField]
    private GameObject orb;
    [SerializeField]
    private GameObject[] objects;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var gameObject in objects)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Starting area trigger");
            foreach (var gameObject in objects)
            {
                gameObject.SetActive(true);
                orb.SetActive(false);
            }
        }
    }
}
