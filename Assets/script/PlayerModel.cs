using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    private int score = 0;
    private int health = 3;

    public int Score => score;
    public int Health => health;

    public void AddScore(int Points)
    {
        score += Points;

    }
    public void TakeDamage()
    {
        health--;

        if(health <=0)
        {
            GameManager.Instance.GameOVer();
        }
    }
}
