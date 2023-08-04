using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float initialSpeed = 5f; // Initial speed of the ball;
    private Rigidbody2D rb;
    private bool ballLaunched = false;
    private Vector2 launchDirection; // Store the launch direction
    private PowerUpManager powerUpManager;
    public float ballSpeedUpMultiplier = 5f;
    public float paddleSizeIncreaseMultiplier = 1.5f;
    private bool isBallSpeedUp = false;
    private float ballSpeedUpDuration = 10f;
    public GameObject[] powerUpPrefabs;
    // Multiplier to increase the ball speed
    private bool powerUp100BallsTriggered = false;
    private int ballCount = 1;
    private int maxBalls = 100;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero; // Setting the initial velocity to zero.
        launchDirection = Vector2.up; // Set the initial launch direction to up.
    }

    void Update()
    {
        if (!ballLaunched)
        {
            // Launch the ball when the player presses the spacebar.
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LaunchBall();
            }
        }
        if (isBallSpeedUp)
        {
            ballSpeedUpDuration -= Time.deltaTime;
            if (ballSpeedUpDuration <= 0f)
            {
                // Reset ball speed to normal after the power-up duration
                isBallSpeedUp = false;
                rb.velocity = rb.velocity.normalized * initialSpeed;
            }
        }
    }

    void LaunchBall()
    {
        rb.velocity = launchDirection.normalized * initialSpeed; // Use the launch direction for initial velocity
        ballLaunched = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Handle ball collisions with the paddle and bricks
        if (collision.gameObject.CompareTag("Paddle"))
        {
            // Calculate the new direction of the ball based on the paddle's position.
            float hitpoint = collision.contacts[0].point.x;
            float paddlecenter = collision.gameObject.transform.position.x;
            float paddleWidth = collision.collider.bounds.size.x;

            float newDirection = (hitpoint - paddlecenter) / paddleWidth;
            launchDirection = new Vector2(newDirection, 1f).normalized; // Update the launch direction
        }
        else if (collision.gameObject.CompareTag("Bricks"))
        {
            // Handle bricks destructions and update the score
            BrickController brickController = collision.gameObject.GetComponent<BrickController>();
            if (brickController != null)
            {
                brickController.HitBrick();

                if (brickController.health <= 0)
                {
                    GameManager.Instance.AddScore(brickController.points);
                }
            }
        }
        else if (collision.gameObject.CompareTag("BottomWall"))
        {
            // If power-up "100 Balls" triggered, spawn more balls
            if (powerUp100BallsTriggered)
            {
                ballCount--;
                if (ballCount <= 0)
                {
                    GameManager.Instance.GameOver();
                    Destroy(gameObject); // Destroy the ball when the game is over
                }
            }
            else
            {
                GameManager.Instance.GameOver();
                Destroy(gameObject); // Destroy the ball when the game is over
            }
        }
    }


    public void IncreaseSpeed(float multiplier)
    {
        rb.velocity *= multiplier;
        isBallSpeedUp = true;
        ballSpeedUpDuration = 10f; // Reset the power-up duration
    }

    public void IncreasePaddleSize(float multiplier)
    {
        PaddleController paddleController = FindObjectOfType<PaddleController>();
        if (paddleController != null)
        {
            paddleController.IncreaseSize(multiplier);
        }
    }
}
