using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventSystem : MonoBehaviour
{
    public static EventSystem Instance { get; private set; }

    // Declare events here
    public event Action<int> OnBrickHit;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void BrickHit(int points)
    {
        OnBrickHit?.Invoke(points);
    }
}
