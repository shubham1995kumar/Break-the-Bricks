using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float moveSpeed = 10f; // speed at which paddle moves
    public float paddleWidth = 2f;//width of the papddle 
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 currentPosition = transform.position;
        currentPosition.x += horizontalInput * moveSpeed * Time.deltaTime;


        // limit paddle movement within the screen
        float halPaddleWidth = paddleWidth / 2f;
        currentPosition.x = Mathf.Clamp(currentPosition.x, -halPaddleWidth, halPaddleWidth);

        transform.position = currentPosition;


    }
}
