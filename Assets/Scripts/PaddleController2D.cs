using UnityEngine;

public class PaddleController2D : MonoBehaviour
{
    public float speed = 10f;
    public bool isPlayerOne = true;
    public float yBound = 4.2f;

    void Update()
    {
        float moveInput = 0f;

        if (isPlayerOne)
        {
            if (Input.GetKey(KeyCode.W)) moveInput = 1f;
            else if (Input.GetKey(KeyCode.S)) moveInput = -1f;
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow)) moveInput = 1f;
            else if (Input.GetKey(KeyCode.DownArrow)) moveInput = -1f;
        }

        Vector3 newPos = transform.position + Vector3.up * moveInput * speed * Time.deltaTime;
        newPos.y = Mathf.Clamp(newPos.y, -yBound, yBound);
        transform.position = newPos;
    }
}