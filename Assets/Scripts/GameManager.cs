using UnityEngine;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    public BallController2D ball;
    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;
    public AudioClip scoreSound;
    public float scoreDelay = 1.5f;

    private int player1Score = 0;
    private int player2Score = 0;
    private AudioSource audioSource;
    private bool isScoring = false;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null) audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Start()
    {
        UpdateUI();
        StartCoroutine(StartGameWithDelay());
    }

    IEnumerator StartGameWithDelay()
    {
        ball.ResetBallPosition();
        yield return new WaitForSeconds(scoreDelay);
        ball.LaunchBall();
    }

    public void Player1Scored()
    {
        if (isScoring) return;
        StartCoroutine(ScoreRoutine(1));
    }

    public void Player2Scored()
    {
        if (isScoring) return;
        StartCoroutine(ScoreRoutine(2));
    }

    IEnumerator ScoreRoutine(int winner)
    {
        isScoring = true;
        ball.ResetBallPosition();

        if (winner == 1) player1Score++;
        else if (winner == 2) player2Score++;

        PlayScoreSound();
        UpdateUI();

        yield return new WaitForSeconds(scoreDelay);

        isScoring = false;
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
        if (player1ScoreText != null) player1ScoreText.text = player1Score.ToString();
        if (player2ScoreText != null) player2ScoreText.text = player2Score.ToString();
    }
}