using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float moveSpeed = 10f; // speed at which paddle moves
    public float paddleWidth = 2f; // width of the paddle
    private bool ballLaunched = false; // flag to check if the ball is launched
    private float halfPaddleWidth; // half of the paddle width

    private bool isPaddleSizeIncreased = false; // flag to check if the paddle size is increased
    private float paddleSizeIncreaseDuration = 3f; // duration for the increased paddle size
    private float paddleSizeIncreaseTimer = 0f; // timer to track the duration

    void Start()
    {
        halfPaddleWidth = paddleWidth / 2f;
    }

    void Update()
    {
        if (isPaddleSizeIncreased)
        {
            paddleSizeIncreaseTimer -= Time.deltaTime;
            if (paddleSizeIncreaseTimer <= 0f)
            {
                // Reset paddle size to normal after the power-up duration
                IncreaseSize(1f); // Reset size to normal (multiplier of 1)
                isPaddleSizeIncreased = false;
            }
        }

        if (!ballLaunched)
        {
            // Move the paddle only when the ball is not launched
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float moveAmount = horizontalInput * moveSpeed * Time.deltaTime;
            Vector2 currentPosition = transform.position;
            currentPosition.x += moveAmount;

            // Get the screen width in world coordinates
            float screenWidthInWorld = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x;

            // Limit paddle movement within the screen
            currentPosition.x = Mathf.Clamp(currentPosition.x, -screenWidthInWorld + halfPaddleWidth, screenWidthInWorld - halfPaddleWidth);

            transform.position = currentPosition;
        }
    }

    public void LaunchBall()
    {
        ballLaunched = true;
    }

    public void IncreaseSize(float multiplier)
    {
        Vector2 currentScale = transform.localScale;
        currentScale.x *= multiplier;
        transform.localScale = currentScale;
        halfPaddleWidth = paddleWidth / 2f;
    }

    public void TriggerPaddleSizeIncrease(float multiplier, float duration)
    {
        if (!isPaddleSizeIncreased)
        {
            IncreaseSize(multiplier);
            isPaddleSizeIncreased = true;
            paddleSizeIncreaseTimer = duration;
        }
        else
        {
            // If the power-up is already active, extend the duration.
            paddleSizeIncreaseTimer += duration;
        }
    }
}
