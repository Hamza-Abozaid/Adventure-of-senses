using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAndDrop : MonoBehaviour {
    public Transform player; // Reference to the player or the object that will hold the item
    public Camera playerCamera; // Reference to the player's camera
    public float pickupRange = 2f; // Range within which the player can pick up items
    public KeyCode pickupKey = KeyCode.E; // Key to press for picking up items
    public KeyCode eatKey = KeyCode.F; // Key to press for eating the item
    public float itemHeightOffset = 1.0f; // How much to raise the item when picked up
    private GameObject currentItem = null; // The currently held item
    public LayerMask ignoreLayers; // Layers to ignore in the raycast
    [SerializeField] Flowchart flowchart;
    [SerializeField] string blockname ;
    void Update() {
        // Check if the player is pressing the pickup key
        if (Input.GetKeyDown(pickupKey)) {
            // If the player is already holding an item, drop it
            if (currentItem != null) {
                DropItem();
            } else {
                // Otherwise, try to pick up an item
                TryPickupItem();
            }
        }

        // Check if the player is pressing the eat key
        if (Input.GetKeyDown(eatKey)) {
            EatItem();
        }
    }

    void TryPickupItem() {
        // Raycast from the camera's position and direction, ignoring specified layers
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, pickupRange, ~ignoreLayers)) {
            Debug.Log("Raycast hit: " + hit.collider.name);

            if (hit.collider != null && hit.collider.CompareTag("PickupItem")) {
                Debug.Log("Picking up item: " + hit.collider.name);

                // If the raycast hits an item with the tag "PickupItem", pick it up
                currentItem = hit.collider.gameObject;
                currentItem.GetComponent<Rigidbody>().isKinematic = true; // Disable physics
                currentItem.transform.SetParent(player); // Attach the item to the player

                // Position it in front of the player and adjust the height
                currentItem.transform.localPosition = new Vector3(0, itemHeightOffset, 1); // Adjust Y position to raise the item
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
            // Check if the item is food by accessing the ItemType component
            ItemType itemType = currentItem.GetComponent<ItemType>();
            if (itemType != null && itemType.isFood) {
                Debug.Log("Eating item: " + currentItem.name);

                // Implement the logic for eating the item here
                // For example: Destroy the item or play an animation

                Destroy(currentItem); // Example action
                flowchart.ExecuteBlock(blockname);
                currentItem = null; // Clear the current item
            } else {
                Debug.Log("No item to eat or item is not food.");
            }
        }
    }
}
