using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FlappyPlane
{
    public class FlappyGameManager : MonoBehaviour
    {
        static FlappyGameManager gameManager;

        public static FlappyGameManager Instance { get { return gameManager; } } 

        private int currentScore = 0;

        FlappyUIManager uiManager; 
        public FlappyUIManager UIManager { get { return uiManager; } }  

        private void Awake()
        {
            gameManager = this; 
            uiManager = FindObjectOfType<FlappyUIManager>(); 
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
            UnityEngine.SceneManagement.SceneManager.LoadScene(currentScene);
        }

        public void ExitGame()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }


        public void AddScore(int score)
        {
            currentScore += score; // ���������� 1�� ����
            Debug.Log("Score: " + currentScore); // ���� ���� ����� ���
            uiManager.UpdateScore(currentScore); // ���� UI�� ���� ���� ���
        }
    }
}
