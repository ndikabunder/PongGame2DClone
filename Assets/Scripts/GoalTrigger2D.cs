using UnityEngine;

public class GoalTrigger2D : MonoBehaviour
{
    public bool isPlayerOneGoal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball") || collision.GetComponent<BallController2D>() != null)
        {
            GameManager manager = FindFirstObjectByType<GameManager>();
            if (manager != null)
            {
                if (isPlayerOneGoal) manager.Player2Scored();
                else manager.Player1Scored();
            }
        }
    }
}