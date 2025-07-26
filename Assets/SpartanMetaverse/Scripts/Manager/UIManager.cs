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

    private PlayZoneTrigger currentZone;

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

    public void ShowPanelUI(PlayZoneTrigger zone) // �̴ϰ��� �ǳ� ǥ��
    {
        currentZone = zone;
        miniGameUIPanel.SetActive(true);
    }

    public void HidePanelUI() // �̴ϰ��� �ǳ� ����
    {
        miniGameUIPanel.SetActive(false);
    }

    public void OnStartButton() // ���� ���� ��ư
    {
        if (currentZone != null)
        {
            GameManager.instance.ChangeScene(currentZone.TargetScene);
        }
    }

    public void OnExitButton() // ���� ���� ��ư
    {
        HidePanelUI();
    }
}
