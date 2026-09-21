using UnityEngine;

public class BallController2D : MonoBehaviour
{
    public float initialSpeed = 10f;
    public AudioClip bounceSound; // Drag file suara pantulan ke slot ini

    private Rigidbody2D rb;
    private AudioSource audioSource;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        LaunchBall();
    }

    public void LaunchBall()
    {
        transform.position = Vector3.zero;
        rb.linearVelocity = Vector2.zero; // Gunakan rb.velocity jika memakai Unity versi lama

        float xDir = Random.Range(0, 2) == 0 ? -1f : 1f;
        float yDir = Random.Range(-0.5f, 0.5f);

        Vector2 direction = new Vector2(xDir, yDir).normalized;
        rb.linearVelocity = direction * initialSpeed;
    }

    // Dipanggil otomatis saat bola membentur collider (Dinding/Paddle)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (bounceSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(bounceSound);
        }
    }
}