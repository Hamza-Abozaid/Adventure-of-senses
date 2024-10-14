using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LEVEL2 : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene("LEVEL2");
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player presses the "2" key
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("LEVEL2");
        }
    }
}
