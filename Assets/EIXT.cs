using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    // Function to quit the game
    public void QuitGame()
    {
        Debug.Log("Game is exiting...");
        Application.Quit();  // This will quit the game in a built version
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the 'C' key is pressed
        if (Input.GetKeyDown(KeyCode.C))
        {
            QuitGame();
        }
    }
}
