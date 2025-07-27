using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestScoreText; // �ְ����� 
    [SerializeField] private GameObject miniGameUIPanel; // �̴ϰ��� �ǳ�UI

    public static UIManager instance;

    private string currentSceneName;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowPanelUI(string sceneName) // �̴ϰ��� �ǳ� ǥ��
    {
        currentSceneName = sceneName;
        miniGameUIPanel.SetActive(true);
    }

    public void HidePanelUI() // �̴ϰ��� �ǳ� ����
    {
        miniGameUIPanel.SetActive(false);
    }

    public void OnStartButton() // ���� ���� ��ư
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void OnExitButton() // ���� ���� ��ư
    {
        HidePanelUI();
    }
}
