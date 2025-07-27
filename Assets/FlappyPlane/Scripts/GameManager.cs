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
        static GameManager gameManager;

        public static GameManager Instance { get { return gameManager; } } 

        private int currentScore = 0;
        public int score;

        UIManager uiManager; 
        public UIManager UIManager { get { return uiManager; } }  

        private void Awake()
        {
            gameManager = this; 
            uiManager = FindObjectOfType<UIManager>(); 
        }

        public void Start()
        {
            uiManager.UpdateScore(0); // UI�Ŵ����� �������� �޼���� 0���� ���� -> ���� ���� �� ������ 0���� �ʱ�ȭ�Ͽ� UI�� ǥ��
        }

        public void GameOver()
        {
            int finalScore = currentScore;
            uiManager.SetRestart(); // UI�Ŵ������� ����� �ȳ� �ؽ�Ʈ Ȱ��ȭ

        }

        public void RestartGame()
        {
            string currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        }

        public void AddScore(int score)
        {
            currentScore += score; // ���������� 1�� ����
            Debug.Log("Score: " + currentScore); // ���� ���� ����� ���
            uiManager.UpdateScore(currentScore); // ���� UI�� ���� ���� ���
        }
    }
}
