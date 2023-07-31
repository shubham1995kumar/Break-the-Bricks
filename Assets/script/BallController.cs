using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    
    // Update is called once per frame
   
      public float initialSpeed = 5f; // Initial speed of the ball;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(1f, 1f).normalized * initialSpeed;
    }
    private void Update()
    {
        
    }
}
