using UnityEngine;

public class SandwichAssembler : MonoBehaviour {
    // Serialized ingredient GameObjects
    [SerializeField] GameObject bottonBread;
    [SerializeField] GameObject topBread;
    [SerializeField] GameObject tomato;
    [SerializeField] GameObject cheese;
    [SerializeField] GameObject lettuce;
    [SerializeField] GameObject onion;

    // Serialized hidden sandwich and position for assembly
    [SerializeField] GameObject hiddenSandwich;

    // Position where the sandwich will be placed
    [SerializeField] Transform assemblyPoint;

    // PointManager reference
    public PointManager pointManager;

    // Check if all ingredients are present
    bool AreIngredientsPresent() {
        return bottonBread != null && topBread != null && tomato != null &&
               cheese != null && lettuce != null && onion != null;
    }

    void Update() {
        // Check if the player has enough points and presses the X key
        if (pointManager.Score >= 5 && Input.GetKeyDown(KeyCode.X)) {
            // Check if all the ingredients are present
            if (AreIngredientsPresent()) {
                // Move the hidden sandwich to the position of this game object
                hiddenSandwich.transform.position = assemblyPoint.position;
                hiddenSandwich.SetActive(true); // Make the sandwich visible

                // Optionally, you can add any other logic needed here (e.g., updating points)
                pointManager.UpdateScore(-5);

                // Optionally, disable or destroy ingredients after assembly
                bottonBread.SetActive(false);
                topBread.SetActive(false);
                tomato.SetActive(false);
                cheese.SetActive(false);
                lettuce.SetActive(false);
                onion.SetActive(false);

                Debug.Log("Sandwich assembled successfully!");
            } else {
                Debug.Log("Ingredients are missing!");
            }
        }
    }
}