using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItems : MonoBehaviour

{
    [SerializeField] Flowchart flowchart;
    [SerializeField] string blockname;
    // Start is called before the first frame update
    void Start()
    {
        flowchart.ExecuteBlock(blockname);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
