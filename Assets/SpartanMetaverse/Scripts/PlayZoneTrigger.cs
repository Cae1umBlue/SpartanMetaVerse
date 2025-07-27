using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayZoneTrigger : MonoBehaviour
{
    [SerializeField] private Scenes sceneName;
    public Scenes TargetScene => sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

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

            if (UIManager.instance != null)
            {
                UIManager.instance.HidePanelUI();
            }
        }
    }
}
