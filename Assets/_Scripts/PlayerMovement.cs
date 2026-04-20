using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private AudioSource audioSource;

    [SerializeField] private float speed = 5f;
    [SerializeField] private GameManagerBehaviour gameManager;

    private float speedMultiplier = 1f;
    private float slowTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (slowTimer > 0f)
        {
            slowTimer -= Time.deltaTime;

            if (slowTimer <= 0f)
            {
                speedMultiplier = 1f;
                slowTimer = 0f;
            }
        }
    }

    void FixedUpdate()
    {
        if (GameController.gameOver) return;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized;

        rb.MovePosition(rb.position + movement * (speed * speedMultiplier) * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coletavel"))
        {
            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.PlayOneShot(audioSource.clip);
            }

            if (gameManager != null)
            {
                gameManager.OnCandyCollected();
            }
        }
    }

    public void ApplySlow(float multiplier, float duration)
    {
        speedMultiplier = multiplier;
        slowTimer = duration;
    }
}