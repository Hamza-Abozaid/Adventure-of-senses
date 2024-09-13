using TMPro;
using UnityEngine;
using TMPro;
public class scores : MonoBehaviour
{
    public int playerScore = 0;  // ÇáÓßæÑ ÇáÍÇáí ááØÇáÈ
    [SerializeField] TextMeshProUGUI ScoreTxt;

    // Method áÊÒæíÏ ÇáÓßæÑ ÈãŞÏÇÑ 5
    public void AddScore()
    {
        playerScore += 5;
        UpdateScoreUI();  // ÊÍÏíË ÇáÜ UI ÈÚÏ ÊÛííÑ ÇáÓßæÑ
    }

    // Method áÊÍÏíË ÇáÜ UI ÇáÎÇÕ ÈÇáÓßæÑ
    void UpdateScoreUI()
    {
        ScoreTxt.text = "Score: " + playerScore;
    }
}