using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayZoneTrigger : MonoBehaviour
{
    [SerializeField] private Scenes sceneName;
    public Scenes TargetScene => sceneName;
    //public bool IsPlayerInside() => isPlayerInside;
    //private bool isPlayerInside = false; // 플레이어가 플레이존에 들어왔는지 유무

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
/*            isPlayerInside = true*/;
            if (UIManager.instance != null)
            {
                UIManager.instance.ShowPanelUI(this);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //isPlayerInside = false;
            if (UIManager.instance != null)
            {
                UIManager.instance.HidePanelUI();
            }
        }
    }
}
