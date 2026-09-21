using UnityEngine;

public class BallController2D : MonoBehaviour
{
    public float initialSpeed = 10f;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        LaunchBall();
    }

    public void LaunchBall()
    {
        transform.position = Vector3.zero;
        rb.linearVelocity = Vector2.zero; // Jika Unity versi lama gunakan rb.velocity

        float xDir = Random.Range(0, 2) == 0 ? -1f : 1f;
        float yDir = Random.Range(-0.5f, 0.5f);

        Vector2 direction = new Vector2(xDir, yDir).normalized;
        rb.linearVelocity = direction * initialSpeed;
    }
}