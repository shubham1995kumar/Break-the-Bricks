using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum GameStates
{
    Playing,
    GameOver
}

public class GameState : MonoBehaviour
{
    public static GameState Instance { get; private set; }
    private GameStates currentState;

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
    private void Start()
    {
        SetState(GameStates.Playing);  //set the initial state to playing ;
    }

    public void SetState(GameStates newState)
    {
        currentState = newState;
        switch(currentState)
        {
            case GameStates.Playing:
                Time.timeScale = 1f; //resume time when playing;
                break;
            case GameStates.GameOver:
                Time.timeScale = 0f; //pause time when game over;
                break;
        }
    }
    public GameStates GetState()
    {
        return currentState;
    }

}

