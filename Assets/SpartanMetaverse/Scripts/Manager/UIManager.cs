using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CurrentScoreText; // ��������
    [SerializeField] private TextMeshProUGUI bestScoreText; // �ְ�����
    [SerializeField] private GameObject miniGameUIPanel;    // �̴ϰ��� �ȳ� �ǳ�UI
    [SerializeField] private GameObject GameOverPanel;      // ���ӿ����� ������ �ǳ�UI

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

    public void ShowPanelUI() // �̴ϰ��� ���� �ǳ� ǥ��
    {
        miniGameUIPanel.SetActive(true);
    }

    public void HidePanelUI() // �̴ϰ��� �ǳ� ����
    {
        miniGameUIPanel.SetActive(false);
    }

    public void EnterMiniGame() // ���� ���� ��ư
    {
        SceneManager.LoadScene(currentSceneName);
    }

    public void OnExitButton() // ���� ���� ��ư
    {
        SceneManager.LoadScene("MainScene");
    }

    public void RestartGame() // ���� �����
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
