using TMPro;
using UnityEngine;
using TMPro;
public class score : MonoBehaviour
{
    public int playerScore = 0;  // ������ ������ ������
    [SerializeField] TextMeshProUGUI ScoreTxt;

    // Method ������ ������ ������ 5
    public void AddScore()
    {
        playerScore += 5;
        UpdateScoreUI();  // ����� ��� UI ��� ����� ������
    }

    // Method ������ ��� UI ����� �������
    void UpdateScoreUI()
    {
        ScoreTxt.text = "Score: " + playerScore;
    }
}