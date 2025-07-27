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
            uiManager.UpdateScore(0); // UI�Ŵ����� �������� �޼���� 0���� ���� -> ���� ���� �� ������ 0���� �ʱ�ȭ�Ͽ� UI�� ǥ��
        }

        public void GameOver()
        {
            int finalScore = currentScore;
            uiManager.SetRestart(); // UI�Ŵ������� ����� �ȳ� �ؽ�Ʈ Ȱ��ȭ

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
            currentScore += score; // ���������� 1�� ����
            Debug.Log("Score: " + currentScore); // ���� ���� ����� ���
            uiManager.UpdateScore(currentScore); // ���� UI�� ���� ���� ���
        }
    }
}
