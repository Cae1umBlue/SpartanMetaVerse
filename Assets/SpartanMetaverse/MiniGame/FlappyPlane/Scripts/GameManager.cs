using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

namespace MiniGames.Flappy
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; } 

        public int currentScore = 0;

        UIManager uiManager; 
        public UIManager UIManager { get { return uiManager; } }

        private void Awake()
        {
            gameManager = this; 
            uiManager = FindObjectOfType<UIManager>(); 
        }

        public void Start()
        {
            uiManager.UpdateScore(0); // UI매니저의 점수갱신 메서드는 0부터 시작 -> 게임 시작 시 점수를 0으로 초기화하여 UI에 표시
        }

        public void GameOver()
        {
            int finalScore = currentScore;
            uiManager.SetRestart(); // UI매니저에서 재시작 안내 텍스트 활성화

        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void ExitGame()
        {
            uiManager.OnExitGame();
        }

        public void AddScore(int score)
        {
            currentScore += score; // 현재점수가 1씩 증가
            Debug.Log("Score: " + currentScore); // 점수 문구 디버거 출력
            uiManager.UpdateScore(currentScore); // 점수 UI에 현재 점수 출력
        }
    }
}
