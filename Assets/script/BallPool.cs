//ballpool.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPool : MonoBehaviour
{
    public GameObject ballPrefab;
    public int initialPoolSize = 100;
    private Queue<GameObject> ballPool = new Queue<GameObject>();

    void Start()
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject ball = Instantiate(ballPrefab);
            ball.SetActive(false);
            ballPool.Enqueue(ball);
        }
    }

    public GameObject GetBall()
    {
        if (ballPool.Count == 0)
        {
            GameObject newBall = Instantiate(ballPrefab);
            return newBall;
        }

        GameObject ball = ballPool.Dequeue();
        ball.SetActive(true);
        return ball;
    }

    public void ReturnBall(GameObject ball)
    {
        ball.SetActive(false);
        ballPool.Enqueue(ball);
    }

    // Function to add balls to the pool
    public void AddBallsToPool(int numBallsToAdd)
    {
        for (int i = 0; i < numBallsToAdd; i++)
        {
            GameObject ball = Instantiate(ballPrefab);
            ball.SetActive(false);
            ballPool.Enqueue(ball);
        }
    }
}
