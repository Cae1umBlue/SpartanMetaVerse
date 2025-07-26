using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestScoreText; // 최고점수 
    [SerializeField] private GameObject miniGameUIPanel; // 미니게임 판넬UI

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

    public void ShowPanelUI(PlayZoneTrigger zone) // 미니게임 판넬 표시
    {
        currentZone = zone;
        miniGameUIPanel.SetActive(true);
    }

    public void HidePanelUI() // 미니게임 판넬 숨김
    {
        miniGameUIPanel.SetActive(false);
    }

    public void OnStartButton() // 게임 시작 버튼
    {
        if (currentZone != null)
        {
            GameManager.instance.ChangeScene(currentZone.TargetScene);
        }
    }

    public void OnExitButton() // 게임 퇴장 버튼
    {
        HidePanelUI();
    }
}
