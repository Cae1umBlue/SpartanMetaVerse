using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FlappyPlane
{
    public class FlappyUIManager : MonoBehaviour
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

        public void OnExitGame()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }

        public void UpdateScore(int socre)
        {
            scoreText.text = socre.ToString();
        }

    }
}
