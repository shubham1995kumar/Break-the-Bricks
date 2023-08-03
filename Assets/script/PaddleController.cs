using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float moveSpeed = 10f; // speed at which paddle moves
    public float paddleWidth = 2f;//width of the papddle 
    private bool ballLaunched = false; // flag to check if the ball is launched
    void Update()
    {
        if (!ballLaunched)
        {
            // Move the paddle only when the ball is not launched
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float moveAmount = horizontalInput * moveSpeed * Time.deltaTime;
            Vector2 currentPosition = transform.position;
            currentPosition.x += moveAmount;

            // Limit paddle movement within the screen
            float halfPaddleWidth = paddleWidth / 2f;
            currentPosition.x = Mathf.Clamp(currentPosition.x, -halfPaddleWidth, halfPaddleWidth);

            transform.position = currentPosition;
        }
    }
    public void LaunchBall()
    {
        ballLaunched = true;
    }
}


