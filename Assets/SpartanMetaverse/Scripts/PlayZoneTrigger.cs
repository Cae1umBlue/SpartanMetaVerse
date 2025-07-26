using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayZoneTrigger : MonoBehaviour
{
    public Scenes targetScene = Scenes.TheStack;
    private bool isPlayerInside = false; // �÷��̾ �÷������� ���Դ��� ����

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInside = true;
            Debug.Log("������ ����");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInside = false;
            Debug.Log("������ ����");
        }
    }

    public bool IsPlayerInside() => isPlayerInside;
}
