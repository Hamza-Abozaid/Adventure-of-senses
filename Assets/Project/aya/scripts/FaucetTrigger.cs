using UnityEngine;
using Fungus; // Import the Fungus namespace

public class FaucetTrigger : MonoBehaviour
{
    public GameObject water;  // Object representing the water
    public Flowchart flowchart; // Reference to the Fungus Flowchart
    public string blockName = "YourBlockName"; // Name of the block to execute
    private int interactionCount = 0; // Counter to track the number of interactions

    void Start()
    {
        water.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactionCount++; // Increase interaction count when the player enters
            water.SetActive(true);

            // Check if the interaction count has reached 4
            if (interactionCount == 4)
            {
                // Execute the specific block in the flowchart
                flowchart.ExecuteBlock(blockName);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            water.SetActive(false);
        }
    }
}
