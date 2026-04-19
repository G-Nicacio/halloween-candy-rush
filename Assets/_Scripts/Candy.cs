using TMPro;
using UnityEngine;

public class Candy : MonoBehaviour
{
    [SerializeField] private TextMeshPro timerText;

    void Update()
    {
        if (timerText != null)
        {
            timerText.text = Mathf.Ceil(GameController.candyTimer).ToString();
        }
    }
}