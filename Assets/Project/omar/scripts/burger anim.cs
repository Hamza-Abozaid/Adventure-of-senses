using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burgeranim : MonoBehaviour
{
    [SerializeField] private Animator myAnimationController;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myAnimationController.SetBool("burger", true);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myAnimationController.SetBool("burger", false);
        }

    }
}
