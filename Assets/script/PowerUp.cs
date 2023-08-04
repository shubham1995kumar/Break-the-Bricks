//powerUP.cs
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum PowerUpType
    {
        Balls100, // Power-up for adding 100 balls to the pool
        BallSpeedUp, // Power-up for increasing ball speed
        PaddleSizeIncrease // Power-up for increasing paddle size
    }

    public PowerUpType powerUpType;
    public float paddleSizeIncreaseMultiplier = 1.5f; // Add this line to control paddle size power-up multiplier
    public float ballSpeedUpMultiplier = 1.5f; // Adjust this value to control the amount of size increase;
    public float paddleSizeIncreaseDuration = 3f; // Duration of paddle size increase

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Paddle"))
        {
            // Apply the power-up effect based on the powerUpType.
            if (powerUpType == PowerUpType.Balls100)
            {
                BallPool ballPool = FindObjectOfType<BallPool>();
                if (ballPool != null)
                {
                    ballPool.AddBallsToPool(100);
                }
            }
            else if (powerUpType == PowerUpType.BallSpeedUp)
            {
                IncreaseBallSpeed(ballSpeedUpMultiplier);
            }
            else if (powerUpType == PowerUpType.PaddleSizeIncrease)
            {
                IncreasePaddleSize(paddleSizeIncreaseMultiplier, paddleSizeIncreaseDuration);
            }

            Destroy(gameObject);
        }
    }

    void IncreaseBallSpeed(float multiplier)
    {
        BallController ballController = FindObjectOfType<BallController>();
        if (ballController != null)
        {
            ballController.IncreaseSpeed(multiplier);
        }
    }

    void IncreasePaddleSize(float multiplier, float duration)
    {
        PaddleController paddleController = FindObjectOfType<PaddleController>();
        if (paddleController != null)
        {
            paddleController.TriggerPaddleSizeIncrease(multiplier, duration);
        }
    }
}
