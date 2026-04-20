using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Painéis")]
    [SerializeField] private GameObject endGamePanel;
    [SerializeField] private GameObject hudPanel;

    [Header("HUD")]
    [SerializeField] private TextMeshProUGUI candiesText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI globalTimerText;

    [Header("Game Over")]
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private TextMeshProUGUI finalTimeText;
    [SerializeField] private GameObject newRecordTextObject;

    private bool gameOverHandled = false;

    void Start()
    {
        if (endGamePanel != null)
            endGamePanel.SetActive(false);

        if (newRecordTextObject != null)
            newRecordTextObject.SetActive(false);
    }

    void Update()
    {
        UpdateHUD();

        if (GameController.gameOver && !gameOverHandled)
        {
            HandleGameOver();
            gameOverHandled = true;
        }
    }

    void UpdateHUD()
    {
        if (candiesText != null)
            candiesText.text = "Doces: " + GameController.candies + "/" + GameController.fee;

        if (scoreText != null)
            scoreText.text = "Score: " + GameController.score;

        if (globalTimerText != null)
            globalTimerText.text = "Taxa em: " + Mathf.Ceil(GameController.globalTimer);
    }

    void HandleGameOver()
    {
        if (hudPanel != null)
            hudPanel.SetActive(false);

        if (endGamePanel != null)
            endGamePanel.SetActive(true);

        if (finalScoreText != null)
            finalScoreText.text = "Pontuação: " + GameController.score;

        if (finalTimeText != null)
            finalTimeText.text = "Tempo sobrevivido: " + Mathf.FloorToInt(GameController.survivalTime) + "s";

        int savedHighScore = PlayerPrefs.GetInt("HighScore", 0);
        bool isNewRecord = GameController.score > savedHighScore;

        if (isNewRecord)
        {
            PlayerPrefs.SetInt("HighScore", GameController.score);
            PlayerPrefs.Save();
        }

        if (newRecordTextObject != null)
        {
            newRecordTextObject.SetActive(isNewRecord);
        }
    }
}