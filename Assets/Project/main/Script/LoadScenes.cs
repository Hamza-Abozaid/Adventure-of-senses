using UnityEngine;
using UnityEngine.SceneManagement; // Import the SceneManagement namespace

public class SceneLoader : MonoBehaviour
{
    // This function loads the scene based on the integer index passed
    public void LoadSceneByIndex(int sceneIndex)
    {
        // Check if the scene index is valid (optional, for safety)
        if (sceneIndex >= 0 && sceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(sceneIndex); // Load the scene using the index
        }
        
    }
}
