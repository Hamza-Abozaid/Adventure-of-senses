using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public int Score;
    public TMP_Text Scoretext;

    // Update is called once per frame
    public void UpdateScore(int Points)
    {
        Score += Points;
        Scoretext.text = "Score: " + Score;
    }
}
