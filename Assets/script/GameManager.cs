using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance { get; private set; }
    public int score = 0;  // player, score 
    public GameObject gameOverPanel;  /// reference to the game over panel
    public TextMeshProUGUI scoreText;

    void Awake()
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
        GameState.Instance.SetState(GameStates.Playing);
        UpdateScoreText();// set the initial state to playing.
    }



    public void AddScore( int points)
    {
        if (GameState.Instance.GetState() == GameStates.Playing)
        {
            score += points;
            UpdateScoreText();
        }
    }


    public void GameOVer()
    {
        if (GameState.Instance.GetState() == GameStates.GameOver)
        {
            gameOverPanel.SetActive(true); // display the game over panel.
            Time.timeScale = 0f; // pause the game 
        }

    }
    public void RestartLevel()
    {
        SceneManager.LoadScene("MainScene"); // reload the current scene to restart
        GameState.Instance.SetState(GameStates.Playing);
        Time.timeScale = 1f;  // reset the time scale after restarting the the level.
    }
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

}
