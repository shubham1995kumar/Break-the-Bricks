using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    public int health = 3;
    public int points = 10;

    public void HitBrick()
    {
        health--;
        if (health ==0)
        {
            Destroy(gameObject);
            EventSystem.Instance.BrickHit(points);
        }
        
    }
}
