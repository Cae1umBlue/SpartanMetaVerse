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

            restartText.gameObject.SetActive(false);
            exitButton.gameObject.SetActive(false);
        }
        public void SetRestart()
        {
            restartText.gameObject.SetActive(true);
            exitButton.gameObject.SetActive(true);
        }

        public void OnExitGame() // Exit 버튼 클릭시 메인씬으로 복귀
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

        public void UpdateScore(int socre)
        {
            scoreText.text = socre.ToString();
        }

    }
}
