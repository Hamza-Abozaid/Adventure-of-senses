using UnityEngine;
using Fungus; // Import the Fungus namespace

public class FaucetTrigger : MonoBehaviour
{
    public GameObject water;
    public Flowchart flowchart;
    private bool hasShownMessage = false; 

    void Start()
    {
        water.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            water.SetActive(true);

          
            if (!hasShownMessage)
            {
                flowchart.ExecuteBlock("New Block"); 
                hasShownMessage = true; 
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            water.SetActive(false);
            flowchart.ExecuteBlock("New Block"); // Execute block when water is off
        }
    }
}
