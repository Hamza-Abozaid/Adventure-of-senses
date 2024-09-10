using TMPro;
using UnityEngine;
using TMPro;
public class score : MonoBehaviour
{
    public int playerScore = 0; 
    [SerializeField] TextMeshProUGUI ScoreTxt;

  
    public void AddScore()
    {
        playerScore += 5;
        UpdateScoreUI(); 
    }

 
    void UpdateScoreUI()
    {
        ScoreTxt.text = "Score: " + playerScore;
    }
}