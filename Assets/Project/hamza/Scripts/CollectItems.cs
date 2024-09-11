using Fungus;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectItems : MonoBehaviour

{
    [SerializeField] Flowchart flowchart;
    [SerializeField] string blockname;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void OnTriggerEnter(Collider other) {
        flowchart.ExecuteBlock(blockname);
        
    }
    private void OnTriggerExit(Collider other) {
        Destroy(gameObject);
    }

}
