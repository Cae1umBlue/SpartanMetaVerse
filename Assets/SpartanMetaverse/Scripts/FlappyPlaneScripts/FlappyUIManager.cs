using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlappyUIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject gameOverUI;
    public Button restartButton;
    public Button exitButton;

    FlappyGameManager gameManager;

    void Start()
    {
        gameManager = FlappyGameManager.Instance;
        gameOverUI.gameObject.SetActive(false);
    }

    public void SetRestart()
    {
        gameOverUI.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void OnRestartButton()
    {
        gameManager.RestartGame();
    }

    public void onExitButton()
    {
        SceneManager.LoadScene("MainScene");
    }
}
