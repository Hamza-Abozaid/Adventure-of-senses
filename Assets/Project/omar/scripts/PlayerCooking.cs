using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCooking : MonoBehaviour {
    public PointManager PointManager;
    [SerializeField] Animator myAnimatorController;
    [SerializeField] Flowchart flowchart;
    [SerializeField] string blockname;
    private void OnCollisionEnter(UnityEngine.Collision collision) {
         if (collision.gameObject.name == "Burger") {
            myAnimatorController.SetBool("Test", true);
        //    PointManager.UpdateScore(1);
            flowchart.ExecuteBlock(blockname);
        }
    }

}
