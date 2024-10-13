using UnityEngine;
using Fungus; // Import the Fungus namespace

public class FaucetTrigger : MonoBehaviour
{
    public GameObject water;  // Object representing the water
    public Flowchart flowchart; // Reference to the Fungus Flowchart
    public string blockName = "YourBlockName"; // Name of the block to execute for the say command
    public PickupAndDrop current;
    private bool hasSaid = false; // Flag to check if say command has been executed
    private bool isNearFaucet = false; // To track if player is near the faucet

    // Flags to check if player is holding the vegetables
    private bool hasTomato = false;
    private bool hasLettuce = false;
    private bool hasOnion = false;

    void Start()
    {
        water.SetActive(false); // Initially turn off water
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player has entered the trigger area
        if (other.CompareTag("Player"))
        {
            isNearFaucet = true; // Player is near the faucet

            // Always turn on water when the player touches the faucet
            ActivateWater();

            if(current.currentItem.layer == 8 && !hasTomato)
            {
               
                hasTomato = true;
            }

            if(!hasLettuce && current.currentItem.layer == 9)
            {
                hasLettuce = true;
            }

            if (!hasOnion && current.currentItem.layer == 11)
            {
                hasOnion = true;
            }

            // If the player is holding all vegetables when near the faucet, execute the say block
            if (hasTomato && hasLettuce && hasOnion && !hasSaid)
            {
                flowchart.ExecuteBlock(blockName); // Call the block when holding all vegetables
                hasSaid = true; // Prevent future executions of the say block
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the player has exited the trigger area
        if (other.CompareTag("Player"))
        {
            isNearFaucet = false; // Player is no longer near the faucet
            water.SetActive(false); // Turn off water
        }
    }

    private void ActivateWater()
    {
        // Turn on the water when player touches the faucet
        water.SetActive(true);
    }
}
