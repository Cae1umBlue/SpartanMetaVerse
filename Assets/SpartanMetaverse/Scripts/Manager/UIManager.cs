using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CurrentScoreText; // 현재점수
    [SerializeField] private TextMeshProUGUI bestScoreText; // 최고점수
    [SerializeField] private GameObject miniGameUIPanel;    // 미니게임 안내 판넬UI
    [SerializeField] private GameObject GameOverPanel;      // 게임오버시 보여줄 판넬UI

    public static UIManager instance;

    private string currentSceneName;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void SetSceneName(string sceneName)
    {
        currentSceneName = sceneName;
    }

    public void ShowPanelUI() // 미니게임 진입 판넬 표시
    {
        miniGameUIPanel.SetActive(true);
    }

    public void HidePanelUI() // 미니게임 판넬 숨김
    {
        miniGameUIPanel.SetActive(false);
    }

    public void EnterMiniGame() // 게임 시작 버튼
    {
        SceneManager.LoadScene(currentSceneName);
    }

    public void OnExitButton() // 게임 퇴장 버튼
    {
        SceneManager.LoadScene("MainScene");
    }

    public void RestartGame() // 게임 재시작
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
