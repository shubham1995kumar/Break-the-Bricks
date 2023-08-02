using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventSystem : MonoBehaviour
{
    private static EventSystem instance;
    public static EventSystem Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<EventSystem>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("EventSystem");
                    instance = obj.AddComponent<EventSystem>();
                }
            }
            return instance;
        }
    }

    // Event for brick hits
    public delegate void BrickHitEventHandler(int points);
    public event BrickHitEventHandler OnBrickHit;

    // Method to trigger the brick hit event
    public void BrickHit(int points)
    {
        if (OnBrickHit != null)
        {
            OnBrickHit(points);
        }
    }
}
