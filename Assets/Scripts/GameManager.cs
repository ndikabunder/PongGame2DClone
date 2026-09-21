using UnityEngine;
using TMPro; // Wajib ada untuk mengakses komponen TextMeshPro

public class GameManager : MonoBehaviour
{
    public BallController2D ball;
    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;

    private int player1Score = 0;
    private int player2Score = 0;

    public void Player1Scored()
    {
        player1Score++;
        UpdateUI();
        ball.LaunchBall();
    }

    public void Player2Scored()
    {
        player2Score++;
        UpdateUI();
        ball.LaunchBall();
    }

    void UpdateUI()
    {
        if (player1ScoreText != null)
            player1ScoreText.text = player1Score.ToString();

        if (player2ScoreText != null)
            player2ScoreText.text = player2Score.ToString();
    }
}