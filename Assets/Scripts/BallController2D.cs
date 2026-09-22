using UnityEngine;

public class BallController2D : MonoBehaviour
{
    public float initialSpeed = 10f;
    public float speedIncreaseOnHit = 1.2f; // Persentase penambahan kecepatan (1.2 = naik 20%)
    public float maxSpeed = 25f;            // Batas kecepatan maksimal agar bola tidak tembus wall
    public AudioClip bounceSound;

    private Rigidbody2D rb;
    private AudioSource audioSource;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null) audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void LaunchBall()
    {
        transform.position = Vector3.zero;
        float xDir = Random.Range(0, 2) == 0 ? -1f : 1f;
        float yDir = Random.Range(-0.5f, 0.5f);

        Vector2 direction = new Vector2(xDir, yDir).normalized;
        rb.linearVelocity = direction * initialSpeed;
    }

    public void ResetBallPosition()
    {
        transform.position = Vector3.zero;
        rb.linearVelocity = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Bunyikan suara pantulan
        if (bounceSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(bounceSound);
        }

        // Cek apakah yang ditabrak adalah Paddle
        PaddleController2D paddle = collision.gameObject.GetComponent<PaddleController2D>();
        if (paddle != null)
        {
            // 1. Jika paddle sedang bergerak, naikkan kecepatan bola
            if (paddle.CurrentVelocityY != 0f)
            {
                Vector2 newVelocity = rb.linearVelocity * speedIncreaseOnHit;

                // Berikan sedikit efek dorongan ke arah gerak paddle (Spin/English effect)
                newVelocity.y += paddle.CurrentVelocityY * 0.25f;

                // Batasi agar kecepatan tidak berlebihan (Clamp)
                rb.linearVelocity = Vector2.ClampMagnitude(newVelocity, maxSpeed);
            }
        }
    }
}