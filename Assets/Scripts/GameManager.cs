using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public BallController2D ball;
    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;
    public AudioClip scoreSound; // Drag file suara gol ke slot ini

    private int player1Score = 0;
    private int player2Score = 0;
    private AudioSource audioSource;

    void Awake()
    {
        // Menambahkan AudioSource secara otomatis ke GameManager jika belum ada
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
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