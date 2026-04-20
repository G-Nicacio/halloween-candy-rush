using TMPro;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText;

    void Start()
    {
        int savedHighScore = PlayerPrefs.GetInt("HighScore", 0);

        if (highScoreText != null)
        {
            highScoreText.text = "Recorde: " + savedHighScore;
        }
    }
}