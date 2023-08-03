

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerModel playerModel;
    private PlayerView playerView;

    void Awake()
    {
        playerModel = GetComponent<PlayerModel>();
        playerView = GetComponent<PlayerView>();
    }

    void Update()
    {
        
    }

    public void HandleBrickHit(int points)
    {
        playerModel.AddScore(points);
    }

    public void HandleBallCollision()
    {
        playerModel.TakeDamage();
    }

}
