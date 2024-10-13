using UnityEngine;
using UnityEngine.UI;

public class ToDoListBtn : MonoBehaviour
{
   
    public Image myImage; // Image to toggle


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            ToggleImageVisibility();
        }
    }

    // Toggle the image visibility
    public void ToggleImageVisibility()
    {
        // If the image is active, hide it. If it's hidden, show it.
        bool isImageActive = myImage.gameObject.activeSelf;
        myImage.gameObject.SetActive(!isImageActive);
    }
}
