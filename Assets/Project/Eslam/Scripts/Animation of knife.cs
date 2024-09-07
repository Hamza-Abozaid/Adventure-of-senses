using UnityEngine;

public class Animationofknife : MonoBehaviour
{

    [SerializeField] private Animator animator;
    private bool isPlayerInTrigger = false;

    void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("The button is pressed, smile please (:");
            animator.SetBool("cutting", true);
            Invoke("StopCutting", 2f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            Debug.Log("Success");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            animator.SetBool("cutting", false);
            CancelInvoke("StopCutting"); 
        }
    }

    private void StopCutting()
    {
        animator.SetBool("cutting", false);
    }
}
