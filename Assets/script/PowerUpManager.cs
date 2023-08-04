// PowerUpManager.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    private BrickController brickReference;

    public void SetBrickReference(BrickController brickController)
    {
        brickReference = brickController;
    }

    void Update()
    {
        if (brickReference == null)
        {
            // If the brick is destroyed, let the power-up fall down.
            transform.Translate(Vector3.down * Time.deltaTime);
        }
    }
}
