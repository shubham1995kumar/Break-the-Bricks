using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMagager : MonoBehaviour
{
    public GameObject[] brickPrefabs; // An array to hold different brick prefabs for each health value.
    public int numRows = 5; // Number of rows of bricks.
    public int numCols = 8; // Number of columns of bricks.
    public float brickSpacingX = 1.0f; // Spacing between bricks in the X-axis.
    public float brickSpacingY = 0.5f; // Spacing between bricks in the Y-axis.

    void Start()
    {
        GenerateBricks();
    }

    void GenerateBricks()
    {
        float halfBrickWidth = brickPrefabs[0].GetComponent<SpriteRenderer>().bounds.size.x * 0.5f;

        float totalBricksWidth = numCols * halfBrickWidth * 2 + (numCols - 1) * brickSpacingX;
        float startX = -totalBricksWidth * 0.5f + halfBrickWidth;

        float halfBrickHeight = brickPrefabs[0].GetComponent<SpriteRenderer>().bounds.size.y * 0.5f;
        float totalBricksHeight = numRows * halfBrickHeight * 2 + (numRows - 1) * brickSpacingY;

        float screenHeight = 2f * Camera.main.orthographicSize;
        float startY = screenHeight * 0.5f - totalBricksHeight * 0.5f + halfBrickHeight;

        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numCols; col++)
            {
                Vector2 brickPosition = new Vector2(startX + col * (halfBrickWidth * 2 + brickSpacingX), startY - row * (halfBrickHeight * 2 + brickSpacingY));
                int brickType = Mathf.Clamp(row, 0, brickPrefabs.Length - 1); // Choose the brick type based on the row (health value).
                Instantiate(brickPrefabs[brickType], brickPosition, Quaternion.identity, transform);
            }
        }
    }

}