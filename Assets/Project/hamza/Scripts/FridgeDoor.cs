using UnityEngine;

public class FridgeDoor : MonoBehaviour {
    private bool isLookingAtFridge = false; // To check if the player is looking at the fridge
    private bool isOpen = false; // To track if the fridge is open or closed
    public float rayDistance = 3f; // The maximum distance for detecting the fridge
    public float openAngle = 120f; // The angle to open the door
    public float closeAngle = 0f; // The angle to close the door
    public float rotationSpeed = 2f; // Speed of the door rotation

    private Quaternion closedRotation; // Store the closed rotation
    private Quaternion openRotation; // Store the open rotation

    void Start() {
        // Set initial closed and open rotations based on the current rotation
        closedRotation = transform.localRotation; // The door's closed position
        openRotation = Quaternion.Euler(0, openAngle, 0) * closedRotation; // The door's open position
    }

    void Update() {
        // Check if the player is looking at the fridge
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance)) {
            // Check if the raycast hit the fridge door
            if (hit.transform == transform) {
                isLookingAtFridge = true;
            } else {
                isLookingAtFridge = false;
            }
        } else {
            isLookingAtFridge = false;
        }

        // Toggle open/close door when 'E' is pressed while looking at the fridge
        if (isLookingAtFridge && Input.GetKeyDown(KeyCode.E)) {
            isOpen = !isOpen; // Toggle between open and close
        }

        // Rotate the door to open or close it smoothly
        if (isOpen) {
            // Rotate towards the open position
            transform.localRotation = Quaternion.Slerp(transform.localRotation, openRotation, Time.deltaTime * rotationSpeed);
        } else {
            // Rotate towards the closed position
            transform.localRotation = Quaternion.Slerp(transform.localRotation, closedRotation, Time.deltaTime * rotationSpeed);
        }
    }
}