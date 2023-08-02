using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance { get; private set; }
    public int score = 0;  // player, score 
    public GameObject gameOverPanel;  /// reference to the game over panel

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

     void Start()
    {
        Time.timeScale = 1f; // ensure ttime scale is set normal at the start 
    }
    
    public void AddScore( int points)
    {
        score += points;
    }


    public void GameOVer()
    {
        gameOverPanel.SetActive(true); // display the game over panel.
        Time.timeScale = 0f; // pause the game 

    }
    public void RestartLevel()
    {
        SceneManager.LoadScene("MainScene"); // reload the current scene to restart
        Time.timeScale = 1f;  // reset the time scale after restarting the the level.
    }
    void OnEnable()
    {
        // Subscribe to events from the event system
        EventSystem.Instance.OnBrickHit += HandleBrickHit;
    }

    void OnDisable()
    {
        // Unsubscribe from events when the GameManager is disabled
        EventSystem.Instance.OnBrickHit -= HandleBrickHit;
    }

    void HandleBrickHit(int points)
    {
        // Handle the event when a brick is hit
        AddScore(points);
    }
}
