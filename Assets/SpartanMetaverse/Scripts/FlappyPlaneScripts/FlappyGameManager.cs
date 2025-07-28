using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyGameManager : MonoBehaviour
{
    static FlappyGameManager gameManager;
    public static FlappyGameManager Instance { get { return gameManager; } }

    private int currentScore = 0;
    private int highScore= 0;

    FlappyUIManager uIManager;
    public FlappyUIManager UIManager { get { return uIManager; } }
    public void Awake()
    {
        gameManager = this;
        uIManager = FindAnyObjectByType<FlappyUIManager>();
    }

    private void Start()
    {
        uIManager.UpdateScore(0);
    }


    public void GameOver()
    {
        uIManager.SetRestart();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        currentScore += score;
        uIManager.UpdateScore(currentScore);
    }
}
