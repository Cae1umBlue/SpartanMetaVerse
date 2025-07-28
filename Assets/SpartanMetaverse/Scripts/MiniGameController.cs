using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameController : MonoBehaviour
{
    public float returnDelay = 1f;  //���� ���ð�
    private bool gameOver = false;     // ���� ���� Ȯ��
    private float elapsedTime = 0f;    // �ð� ������ ����

    public void EndMiniGame(bool success, int finalScore)
    {
        if (gameOver) return;
        gameOver = true;

        // ���� ����
        ScoreManager.Instance.score = finalScore;
        ScoreManager.Instance.SaveHighScore();
        PlayerPrefs.SetInt("LastScore", finalScore);
        PlayerPrefs.Save();


        // Ÿ�̸� �ʱ�ȭ
        elapsedTime = 0f;
    }

    void Update()
    {
        // ���� ���� �� �ð� ���� �� ���� �ð� �� �� ����
        if (gameOver)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= returnDelay)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
            }
        }
    }
}


