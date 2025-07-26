using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace FlappyPlane
{
    public class UIManager : MonoBehaviour
    {
        public TextMeshProUGUI restartText;
        public TextMeshProUGUI scoreText;

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
        }
        public void SetRestart()
        {
            restartText.gameObject.SetActive(true);
        }

        public void UpdateScore(int socre)
        {
            scoreText.text = socre.ToString();
        }

    }
}
