using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAndDrop : MonoBehaviour {
    public Transform player; // Reference to the player or the object that will hold the item
    public Camera playerCamera; // Reference to the player's camera
    public float pickupRange = 5f; // Temporarily increased range for testing
    public KeyCode pickupKey = KeyCode.E; // Key to press for picking up items
    public KeyCode eatKey = KeyCode.F; // Key to press for eating the item
    public float itemHeightOffset = 1.0f; // How much to raise the item when picked up
    private GameObject currentItem = null; // The currently held item
    public Flowchart flowchart;
    public Flowchart waterOn;
    public string blockname;
    private List<int> collectedVegetables = new List<int>();

    void Update() {
        // Debug raycast visualization to help track where it's aiming
        Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * pickupRange, Color.red, 1.0f);

        // Check if the player is pressing the pickup key
        if (Input.GetKeyDown(pickupKey)) {
            if (currentItem != null) {
                DropItem();
            } else {
                TryPickupItem();
            }
        }

        // Check if the player is pressing the eat key
        if (Input.GetKeyDown(eatKey)) {
            EatItem();
        }
    }

    void TryPickupItem() {
        RaycastHit hit;
        // Simpler raycast without layer mask for testing
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, pickupRange)) {
            Debug.Log("Raycast hit: " + hit.collider.name);

            if (hit.collider != null && hit.collider.CompareTag("PickupItem")) {
                Debug.Log("Picking up item: " + hit.collider.name);

                // Pickup logic
                currentItem = hit.collider.gameObject;
                currentItem.GetComponent<Rigidbody>().isKinematic = true; // Disable physics
                currentItem.transform.SetParent(player); // Attach the item to the player
                currentItem.transform.localPosition = new Vector3(0, itemHeightOffset, 1); // Adjust Y position to raise the item
                CollectVegetable(currentItem.layer);

            }
        } else {
            Debug.Log("Raycast did not hit anything.");
        }
    }

    void DropItem() {
        if (currentItem != null) {
            // Detach the item from the player
            currentItem.transform.SetParent(null);
            currentItem.GetComponent<Rigidbody>().isKinematic = false; // Enable physics
            currentItem = null; // Clear the current item
            Debug.Log("Item dropped.");
        }
    }

    void EatItem() {
        if (currentItem != null) {
            ItemType itemType = currentItem.GetComponent<ItemType>();
            if (itemType != null && itemType.isFood) {
                Debug.Log("Eating item: " + currentItem.name);

                Destroy(currentItem); // Destroy after eating
                flowchart.ExecuteBlock(blockname);
                currentItem = null;
            } else {
                Debug.Log("No item to eat or item is not food.");
            }
        }
    }
    

    // Method to collect a vegetable
    public void CollectVegetable(int vegetable)
    {
        // Check if the vegetable is already in the list
        if (!collectedVegetables.Contains(vegetable))
        {
            // Add vegetable to the list if it's not already there
            collectedVegetables.Add(vegetable);
           
            // Check if four unique vegetables have been collected
            if (CheckVegetablesCollected())
            {
                waterOn.ExecuteBlock("New Block");
            }
        }
       
    }

    // Method to check if 4 unique vegetables are collected
    private bool CheckVegetablesCollected()
    {
        return collectedVegetables.Count == 5;
    }

    // Example of converting the list to an array if needed
    public int[] GetCollectedVegetablesArray()
    {
        return collectedVegetables.ToArray();
    }
    public void ResetCollectedVegetables()
    {
        collectedVegetables.Clear();
    }
}