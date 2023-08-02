using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPool : MonoBehaviour
{
    public GameObject ballPrefab; // the prefab of the ball to be pooled
    public int poolSize = 100;  // the number of balls to be pooled

    private List<GameObject> ballPool = new List<GameObject>();

    private void Start()
    {
        for (int i=0; i< poolSize; i++)
        {
            GameObject ball = Instantiate(ballPrefab);
            ball.SetActive(false);
            ballPool.Add(ball);
        }
    }
    public GameObject GetBall()
    {
        for( int i = 0; i<ballPool.Count; i++)
        {
            if(!ballPool[i].activeInHierarchy)
            {
                return ballPool[i];
            }
        }
        return null;
    }
}
