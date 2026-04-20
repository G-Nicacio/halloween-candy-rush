using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("Music")]
    [SerializeField] private AudioClip gameMusic;
    [SerializeField] private AudioClip menuMusic;

    [Header("Hazard SFX")]
    [SerializeField] private AudioClip loseCandyClip;
    [SerializeField] private AudioClip reduceCandyTimerClip;
    [SerializeField] private AudioClip reduceGlobalTimerClip;
    [SerializeField] private AudioClip slowPlayerClip;

    private bool gameOverMusicSwapped = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        if (musicSource != null && gameMusic != null)
        {
            musicSource.clip = gameMusic;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    void Update()
    {
        if (GameController.gameOver && !gameOverMusicSwapped)
        {
            SwapToMenuMusic();
            gameOverMusicSwapped = true;
        }
    }

    private void SwapToMenuMusic()
    {
        if (musicSource != null && menuMusic != null)
        {
            musicSource.Stop();
            musicSource.clip = menuMusic;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public void PlayLoseCandySound()
    {
        if (sfxSource != null && loseCandyClip != null)
        {
            sfxSource.PlayOneShot(loseCandyClip);
        }
    }

    public void PlayReduceCandyTimerSound()
    {
        if (sfxSource != null && reduceCandyTimerClip != null)
        {
            sfxSource.PlayOneShot(reduceCandyTimerClip);
        }
    }

    public void PlayReduceGlobalTimerSound()
    {
        if (sfxSource != null && reduceGlobalTimerClip != null)
        {
            sfxSource.PlayOneShot(reduceGlobalTimerClip);
        }
    }

    public void PlaySlowPlayerSound()
    {
        if (sfxSource != null && slowPlayerClip != null)
        {
            sfxSource.PlayOneShot(slowPlayerClip);
        }
    }
}