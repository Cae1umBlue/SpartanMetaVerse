using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

    public class UIManager : MonoBehaviour
    {
        public TextMeshProUGUI currentScoreText;
        public TextMeshProUGUI bestScoreText;
        public Image scoreBoard;
        public Button restartButton;
        public Button exitButton;

        MiniGameEndHandler gameEndHandler;
        public MiniGameEndHandler MiniGameEndHandler { get { return gameEndHandler; } }

        void Start()
        {
            gameEndHandler = FindObjectOfType<MiniGameEndHandler>();

            if (gameEndHandler == null)
            {
                Debug.LogError("MiniGameEndHandler가 씬에 없습니다!");
            }

            scoreBoard.gameObject.SetActive(false);

        }
        public void SetRestart()
        {
            scoreBoard.gameObject.SetActive(true);
        }

        public void OnRestartButton()
        {
            GameManager.Instance.RestartGame();
        }

        public void OnExitGame()
        {
            gameEndHandler.score = GameManager.Instance.currentScore;
            gameEndHandler.EndMiniGame();
        }

        public void UpdateScore(int socre)
        {
            currentScoreText.text = socre.ToString();
        }
    }
