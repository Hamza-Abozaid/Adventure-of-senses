using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public int Score;

    // Update is called once per frame
    public void UpdateScore(int Points)
    {
        Score += Points;
    }
}
