using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagLine : MonoBehaviour
{
    public Transform kitchen; // Assign in the inspector
    public Transform garden;  // Assign in the inspector
    public int numberOfZigs = 10;
    public float zigHeight = 0.5f;

    void Start()
    {
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = numberOfZigs + 1;

        Vector3 startPos = kitchen.position;
        Vector3 endPos = garden.position;

        for (int i = 0; i <= numberOfZigs; i++)
        {
            float t = (float)i / numberOfZigs;
            Vector3 position = Vector3.Lerp(startPos, endPos, t);
            position.y += Mathf.Sin(t * Mathf.PI * numberOfZigs) * zigHeight;
            lineRenderer.SetPosition(i, position);
        }
    }
}
