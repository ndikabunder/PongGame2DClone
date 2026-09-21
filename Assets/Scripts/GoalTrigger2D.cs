using UnityEngine;

public class GoalTrigger2D : MonoBehaviour
{
    public bool isGoalForPlayer1;
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<BallController2D>() != null)
        {
            if (isGoalForPlayer1) gameManager.Player1Scored();
            else gameManager.Player2Scored();
        }
    }
}