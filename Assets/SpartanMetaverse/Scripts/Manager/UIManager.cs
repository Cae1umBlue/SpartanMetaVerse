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

    public static UIManager instance;

    private string currentSceneName;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ShowPanelUI(string sceneName) // �̴ϰ��� ���� �ǳ� ǥ��
    {
        currentSceneName = sceneName;
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
}
