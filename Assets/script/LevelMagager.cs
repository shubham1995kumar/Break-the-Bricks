// LevelManager.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMagager : MonoBehaviour
{
    public GameObject[] brickPrefabs;
    public GameObject[] powerUpPrefabs;
    public int numRows = 5; // Number of rows of bricks.
    public int numCols = 8; // Number of columns of bricks.
    public float brickSpacingX = 1.0f; // Spacing between bricks in the X-axis.
    public float brickSpacingY = 0.5f; // Spacing between bricks in the Y-axis.
    public float powerUpSpawnChance = 0.2f;
    private int totalPowerUps = 5; // Total number of power-ups to spawn in the level

    void Start()
    {
        Debug.Log("Brick Prefabs count: " + brickPrefabs.Length);
        Debug.Log("Power-up Prefabs count: " + powerUpPrefabs.Length);
        GenerateBricks();
    }

    void GenerateBricks()
    {
        if (brickPrefabs == null || brickPrefabs.Length == 0)
        {
            Debug.LogError("No brick prefabs assigned to brickPrefabs array.");
            return;
        }

        float halfBrickWidth = brickPrefabs[0].GetComponent<SpriteRenderer>().bounds.size.x * 0.5f;
        float halfBrickHeight = brickPrefabs[0].GetComponent<SpriteRenderer>().bounds.size.y * 0.5f;

        float totalBricksWidth = numCols * halfBrickWidth * 2 + (numCols - 1) * brickSpacingX;
        float totalBricksHeight = numRows * halfBrickHeight * 2 + (numRows - 1) * brickSpacingY;

        float screenHeight = 2f * Camera.main.orthographicSize;
        float startY = screenHeight * 0.5f - totalBricksHeight * 0.5f + halfBrickHeight;
        int prefabIndex = 0;

        // Create a list of bricks that can potentially spawn power-ups
        List<GameObject> potentialPowerUpBricks = new List<GameObject>();

        // Loop through rows
        for (int row = 0; row < numRows; row++)
        {
            float startX = -totalBricksWidth * 0.5f + halfBrickWidth;
            prefabIndex = row % brickPrefabs.Length;

            for (int col = 0; col < numCols; col++)
            {
                Vector2 brickPosition = new Vector2(startX + col * (halfBrickWidth * 2 + brickSpacingX), startY - row * (halfBrickHeight * 2 + brickSpacingY));
                
                // Create the brick
                GameObject newBrick = Instantiate(brickPrefabs[prefabIndex], brickPosition, Quaternion.identity, transform);


                potentialPowerUpBricks.Add(newBrick);


            }
        }

        // Randomly choose five bricks from the potentialPowerUpBricks list to spawn power-ups
        for (int i = 0; i < totalPowerUps && potentialPowerUpBricks.Count > 0; i++)
        {
            int randomIndex = Random.Range(0, potentialPowerUpBricks.Count);
            GameObject brickWithPowerUp = potentialPowerUpBricks[randomIndex];
            BrickController brickController = brickWithPowerUp.GetComponent<BrickController>();
            if (brickController != null && !brickController.HasPowerUp())
            {
                brickController.SetPowerUpPrefab(powerUpPrefabs[Random.Range(0, powerUpPrefabs.Length)]);
            }
            potentialPowerUpBricks.RemoveAt(randomIndex);
        }

        // Spawn any remaining power-ups
        for (int i = 0; i < potentialPowerUpBricks.Count; i++)
        {
            GameObject brickWithPowerUp = potentialPowerUpBricks[i];
            BrickController brickController = brickWithPowerUp.GetComponent<BrickController>();
            if (brickController != null)
            {
                brickController.SetPowerUpPrefab(null);
            }
        }
    }
}
