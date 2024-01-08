using UnityEngine;

public class StartingScript : MonoBehaviour
{
    [SerializeField]
    private GameObject orb;
    [SerializeField]
    private GameObject[] objects;
    [SerializeField]
    private GameObject paintingLight;
    public audio audioScript;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var gameObject in objects)
        {
            gameObject.SetActive(false);
        }
        paintingLight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("AUDIO REMAINING TIME: " + audioScript.remainingTime());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // float remainingIntroTime = introMusic.clip.length - introMusic.time;
            
            audioScript.PlayBackgroundMusic();
            //Debug.Log("Starting area trigger");
            foreach (var gameObject in objects)
            {
                if (gameObject.CompareTag("Trigger1"))
                {
                    Invoke("ActivateObject", audioScript.remainingTime(0)+audioScript.trackTime(2)-.25f);
                }
                else
                {
                    gameObject.SetActive(true);
                    orb.SetActive(false);
                }
            }
        }
    }
    private void ActivateObject()
    {
        // Set the GameObject active after one minute
        if (objects[0] != null)
        {
            objects[0].SetActive(true);
            paintingLight.SetActive(true);
            //singing starts when objects get activated
        }
    }



}
