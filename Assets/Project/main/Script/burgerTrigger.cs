using UnityEngine;
using Fungus; // Import the Fungus namespace

public class burgerTrigger : MonoBehaviour
{
    public GameObject burger;
    public Flowchart flowchart; // Reference to your Flowchart
    private bool hasShownMessage = false; // To track if the message has been shown

    void Start()
    {
        burger.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            burger.SetActive(true);

            // Only show the Say dialogue once when faucet is turned on for the first time
            if (!hasShownMessage)
            {
                flowchart.ExecuteBlock("New Block"); // Execute block when water is on for the first time
                hasShownMessage = true; // Prevent further executions
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            burger.SetActive(false);
            // No flowchart execution on faucet turning off
        }
    }
}