using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFridgeScript : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private bool isPlayerInTrigger = false;

    void Update() {
        if (isPlayerInTrigger) {
            animator.SetBool("OpenFridge", true);
            Invoke("StopCutting", 2f);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            isPlayerInTrigger = true;
            Debug.Log("Success");
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            isPlayerInTrigger = false;
            animator.SetBool("OpenFridge", false);
            CancelInvoke("StopCutting");
        }
    }

    private void StopCutting() {
        animator.SetBool("OpenFridge", false);
    }

}
