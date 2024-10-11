using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class validtionScript : MonoBehaviour
{
    public PointManager pointManager;
    public string stickableLayer = "StickableLayer"; // الـ Layer الجديد الذي تريد تعيينه

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (pointManager.Score == 5)
        {
            gameObject.layer = LayerMask.NameToLayer(stickableLayer);  // تعيين الـ Layer الجديد
        }
    }
}
