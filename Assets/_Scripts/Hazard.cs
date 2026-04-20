using UnityEngine;

public class Hazard : MonoBehaviour
{
    public enum HazardType
    {
        LoseCandy,
        ReduceCandyTimer,
        ReduceGlobalTimer,
        SlowPlayer
    }

    [Header("Tipo do obstáculo")]
    [SerializeField] private HazardType hazardType;

    [Header("Configurações")]
    [SerializeField] private float candyTimerPenalty = 5f;
    [SerializeField] private float globalTimerPenalty = 3f;
    [SerializeField] private float slowMultiplier = 0.5f;
    [SerializeField] private float slowDuration = 5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        if (GameController.gameOver) return;

        PlayerMovement player = other.GetComponent<PlayerMovement>();

        switch (hazardType)
        {
            case HazardType.LoseCandy:
                GameController.LoseOneCandy();

                if (AudioManager.instance != null)
                    AudioManager.instance.PlayLoseCandySound();
                break;

            case HazardType.ReduceCandyTimer:
                GameController.ReduceCandyTimer(candyTimerPenalty);

                if (AudioManager.instance != null)
                    AudioManager.instance.PlayReduceCandyTimerSound();
                break;

            case HazardType.ReduceGlobalTimer:
                GameController.ReduceGlobalTimer(globalTimerPenalty);

                if (AudioManager.instance != null)
                    AudioManager.instance.PlayReduceGlobalTimerSound();
                break;

            case HazardType.SlowPlayer:
                if (player != null)
                {
                    player.ApplySlow(slowMultiplier, slowDuration);
                }

                if (AudioManager.instance != null)
                    AudioManager.instance.PlaySlowPlayerSound();
                break;
        }

        Destroy(gameObject);
    }
}