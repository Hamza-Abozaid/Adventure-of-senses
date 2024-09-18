using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()

    {
        SceneManager.LoadScene("LevelsPage");

    }

    // Update is called once per frame
    public void ExitGame()
    {
        Application.Quit();
    }
}