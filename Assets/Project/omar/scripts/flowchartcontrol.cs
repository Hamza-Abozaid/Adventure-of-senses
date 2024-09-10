using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowchartcontrol : MonoBehaviour
{
    [SerializeField] string BlockName;
    [SerializeField] Flowchart flowchart;
    bool Area = false;
    private void Update() {

        Execution();
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Area = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            Area = false;
        }
    }
    void Execution() {
        if (Area && Input.GetKeyDown(KeyCode.E)) {

            flowchart.ExecuteBlock(BlockName);
        }
    }
}
