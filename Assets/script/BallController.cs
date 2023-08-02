using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    
    // Update is called once per frame
   
      public float initialSpeed = 5f; // Initial speed of the ball;
     private Rigidbody2D rb;
     private bool ballLaunched = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero; //setting the initial velocity to zero.
    }
     void Update()
    {
       if (!ballLaunched)
        {
            //lauch the ball when the player presses the spacebar.
            if(Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector2(1f, 1f).normalized * initialSpeed;
                ballLaunched = true;
            }
      
        } 
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        // handle ball collisions with the paadle and bricks
        if (collision.gameObject.CompareTag("Paddle"))
        {
            //calculate the new direction of the ball based on the paddle,s position.
            float hitpoint = collision.contacts[0].point.x;
            float paddlecenter = collision.gameObject.transform.position.x;
            float paddleWidth = collision.collider.bounds.size.x;

            float newDirection = (hitpoint - paddlecenter) / paddleWidth;
            Vector2 ballDirection = new Vector2(newDirection, 1f).normalized;
            rb.velocity = ballDirection * initialSpeed;
        }
        else if(collision.gameObject.CompareTag("Bricks"))
        {
            //handle bricks destructions and update the score
            BrickController brickController = collision.gameObject.GetComponent<BrickController>();
            if(brickController != null)
            {
                brickController.HitBrick();
                GameManager.Instance.AddScore(brickController.points);
            }

        }
        if (collision.gameObject.CompareTag("BottomWall"))
        {
            GameManager.Instance.GameOVer();
            Destroy(gameObject); ///destroy the ball when the game is over 
        }
    }
}
