using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public BallController2D ball;
    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;
    public AudioClip scoreSound;

    private int player1Score = 0;
    private int player2Score = 0;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Start()
    {
        // Memastikan teks UI langsung berubah menjadi '0' begitu game dijalankan
        UpdateUI();
    }

    public void Player1Scored()
    {
        player1Score++;
        PlayScoreSound();
        UpdateUI();
        ball.LaunchBall();
    }

    public void Player2Scored()
    {
        player2Score++;
        PlayScoreSound();
        UpdateUI();
        ball.LaunchBall();
    }

    void PlayScoreSound()
    {
        if (scoreSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(scoreSound);
        }
    }

    void UpdateUI()
    {
        if (player1ScoreText != null)
            player1ScoreText.text = player1Score.ToString();

        if (player2ScoreText != null)
            player2ScoreText.text = player2Score.ToString();
    }
}