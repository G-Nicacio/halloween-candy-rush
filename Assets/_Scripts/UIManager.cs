using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject endGamePanel;
    [SerializeField] private GameObject hudPanel;

    [SerializeField] private TextMeshProUGUI candiesText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI globalTimerText;

    void Start()
    {
        if (endGamePanel == null)
        {
            Debug.LogError("End Game Panel não foi atribuído no Inspector!");
            return;
        }

        endGamePanel.SetActive(false);
    }

    void Update()
    {
        if (candiesText != null)
            candiesText.text = "Doces: " + GameController.candies + "/" + GameController.fee;

        if (scoreText != null)
            scoreText.text = "Score: " + GameController.score;

        if (globalTimerText != null)
            globalTimerText.text = "Taxa em: " + Mathf.Ceil(GameController.globalTimer).ToString();

        if (GameController.gameOver)
        {
            endGamePanel.SetActive(true);
            hudPanel.SetActive(false);
        }
    }
}