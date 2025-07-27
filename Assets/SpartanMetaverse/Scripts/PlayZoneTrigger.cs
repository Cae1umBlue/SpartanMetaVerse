using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayZoneTrigger : MonoBehaviour
{
    [SerializeField] private string sceneName; //불러오고자 하는 씬 이름
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            if (UIManager.instance != null)
            {
                UIManager.instance.ShowPanelUI(sceneName);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            if (UIManager.instance != null)
            {
                UIManager.instance.HidePanelUI();
            }
        }
    }
}
