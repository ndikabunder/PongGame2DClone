using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleController2D : MonoBehaviour
{
    public float speed = 10f;
    public float yBound = 3.8f;
    public bool isPlayerOne = true; // Centang di PaddleLeft, hilangkan centang di PaddleRight

    public float CurrentVelocityY { get; private set; }

    void Update()
    {
        if (Keyboard.current == null) return;

        float moveInput = 0f;

        if (isPlayerOne)
        {
            if (Keyboard.current.wKey.isPressed) moveInput = 1f;
            else if (Keyboard.current.sKey.isPressed) moveInput = -1f;
        }
        else
        {
            if (Keyboard.current.upArrowKey.isPressed) moveInput = 1f;
            else if (Keyboard.current.downArrowKey.isPressed) moveInput = -1f;
        }

        if (moveInput != 0f)
        {
            Vector3 newPos = transform.position + Vector3.up * moveInput * speed * Time.deltaTime;
            newPos.y = Mathf.Clamp(newPos.y, -yBound, yBound);
            transform.position = newPos;

            CurrentVelocityY = moveInput * speed;
        }
        else
        {
            CurrentVelocityY = 0f;
        }
    }
}