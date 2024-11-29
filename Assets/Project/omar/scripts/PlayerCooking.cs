using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCooking : MonoBehaviour {
    [SerializeField] Animator myAnimatorController;
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "Burger") {
            myAnimatorController.SetBool("Test", true);
        }
    }
   
}
