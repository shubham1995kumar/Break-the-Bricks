// BrickController.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    public int health = 3;
    public int points = 10;
    public GameObject powerUpPrefab; // Assign the power-up prefab in the Inspector.
    private bool isDestroyed = false;
    private bool hasPowerUp = false; // Add a flag to track if the brick already has a power-up.

    public bool HasPowerUp()
    {
        return powerUpPrefab != null;
    }

    public void SetPowerUpPrefab(GameObject prefab)
    {
        powerUpPrefab = prefab;
    }

    public void HitBrick()
    {
        health--;
        if (health == 0 && !isDestroyed)
        {
            DropPowerUp(); // Drop the power-up before destroying the brick
            isDestroyed = true;
            Destroy(gameObject);
            EventSystem.Instance.BrickHit(points);
        }
    }

    private void DropPowerUp()
    {
        if (powerUpPrefab != null && !hasPowerUp)
        {
            Instantiate(powerUpPrefab, transform.position, Quaternion.identity);
            hasPowerUp = true; // Set the flag to true, indicating the brick has a power-up.
        }
    }
}
