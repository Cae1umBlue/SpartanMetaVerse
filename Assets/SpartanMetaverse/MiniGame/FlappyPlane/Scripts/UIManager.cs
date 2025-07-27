using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MiniGames.Flappy
{
    public class UIManager : MonoBehaviour
    {
        public TextMeshProUGUI restartText;
        public TextMeshProUGUI scoreText;
        public Button exitButton;

        MiniGameEndHandler gameEndHandler;
        public MiniGameEndHandler MiniGameEndHandler { get { return gameEndHandler; } }

        void Start()
        {
            if (restartText == null)
            {
                Debug.Log("restart text is null");
            }

            if (scoreText == null)
            {
                Debug.Log("score text is null");
            }

            gameEndHandler = FindObjectOfType<MiniGameEndHandler>();

            if (gameEndHandler == null)
            {
                Debug.LogError("MiniGameEndHandler가 씬에 없습니다!");
            }

            restartText.gameObject.SetActive(false);
            exitButton.gameObject.SetActive(false);
        }
        public void SetRestart()
        {
            restartText.gameObject.SetActive(true);
            exitButton.gameObject.SetActive(true);
        }

        public void OnExitGame()
        {
            gameEndHandler.score = GameManager.Instance.currentScore;
            gameEndHandler.EndMiniGame();
        }

        public void UpdateScore(int socre)
        {
            scoreText.text = socre.ToString();
        }
    }
}
