using UnityEngine;
using Fungus; // Import the Fungus namespace

public class FaucetTrigger : MonoBehaviour
{
    public GameObject water;  // Object representing the water
    public Flowchart flowchart; // Reference to the Fungus Flowchart
    public string sayBlockName = "SayBlockName"; // Name of the block to execute for the say command
    public string actionBlockName = "YourActionBlockName"; // Name of the block to execute when a vegetable touches the trigger
    private bool hasSaid = false; // Flag to check if say command has been executed

    void Start()
    {
        water.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is one of the specified vegetables by layer
        int layer = other.gameObject.layer;

        if (layer == LayerMask.NameToLayer("Tomato") ||
            layer == LayerMask.NameToLayer("Lettuce") ||
            layer == LayerMask.NameToLayer("Onion"))
        {
            // If the say command has not been executed, execute it
            if (!hasSaid)
            {
                flowchart.ExecuteBlock(sayBlockName); // Call the say block
                hasSaid = true; // Set the flag to true to prevent future executions
            }

            // Activate the water object when a vegetable collides
            water.SetActive(true);

            // Execute the specific block in the flowchart
            flowchart.ExecuteBlock(actionBlockName);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Deactivate the water when the vegetable exits the trigger
        int layer = other.gameObject.layer;

        if (layer == LayerMask.NameToLayer("Tomato") ||
            layer == LayerMask.NameToLayer("Lettuce") ||
            layer == LayerMask.NameToLayer("Onion"))
        {
            water.SetActive(false);
        }
    }
}
