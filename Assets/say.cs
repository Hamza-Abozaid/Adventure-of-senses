using UnityEngine;
using Fungus; // Import the Fungus namespace

public class say : MonoBehaviour
{
    public Flowchart flowchart; // Reference to your Flowchart
    private bool hasExecuted = false; // Boolean to track if block has been executed

    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasExecuted)
        {
            flowchart.ExecuteBlock("New Block"); // Execute block only once
            hasExecuted = true; // Prevent future executions
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Do nothing or you can reset hasExecuted here if needed
    }
}
