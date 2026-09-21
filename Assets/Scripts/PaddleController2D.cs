using UnityEngine;
using UnityEngine.InputSystem; // Import paket Input System terbaru

public class PaddleController2D : MonoBehaviour
{
    public float speed = 10f;
    public bool isPlayerOne = true;
    public float yBound = 4.2f;

    private float moveInput = 0f;

    void Update()
    {
        // Baca input keyboard menggunakan kelas Keyboard dari Input System baru
        Keyboard currentKeyboard = Keyboard.current;

        // Cegah error jika keyboard tidak terdeteksi
        if (currentKeyboard == null) return;

        moveInput = 0f;

        if (isPlayerOne)
        {
            // Kontrol Player 1: Tombol W dan S
            if (currentKeyboard.wKey.isPressed)
            {
                moveInput = 1f;
            }
            else if (currentKeyboard.sKey.isPressed)
            {
                moveInput = -1f;
            }
        }
        else
        {
            // Kontrol Player 2: Tombol Panah Atas dan Panah Bawah
            if (currentKeyboard.upArrowKey.isPressed)
            {
                moveInput = 1f;
            }
            else if (currentKeyboard.downArrowKey.isPressed)
            {
                moveInput = -1f;
            }
        }

        // Terapkan pergerakan paddle
        Vector3 newPos = transform.position + Vector3.up * moveInput * speed * Time.deltaTime;
        newPos.y = Mathf.Clamp(newPos.y, -yBound, yBound);
        transform.position = newPos;
    }
}