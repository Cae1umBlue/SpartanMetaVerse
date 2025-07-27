using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameController : MonoBehaviour
{
    public GameObject gameOverPanel;   // 종료 시 표시할 UI
    public Text resultText;
    public float returnDelay = 2.5f;   // 복귀까지 대기 시간

    private bool gameOver = false;     // 종료 상태 확인
    private float elapsedTime = 0f;    // 시간 누적용 변수

    public void EndMiniGame(bool success, int finalScore)
    {
        if (gameOver) return;
        gameOver = true;

        // 점수 저장
        ScoreManager.Instance.score = finalScore;
        ScoreManager.Instance.SaveHighScore();
        PlayerPrefs.SetInt("LastScore", finalScore);
        PlayerPrefs.Save();

        // UI 출력
        gameOverPanel.SetActive(true);
        resultText.text = success ? "성공!" : "실패!";

        // 타이머 초기화
        elapsedTime = 0f;
    }

    void Update()
    {
        // 게임 종료 후 시간 누적 → 일정 시간 후 맵 복귀
        if (gameOver)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= returnDelay)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("MainMap");
            }
        }
    }
}


