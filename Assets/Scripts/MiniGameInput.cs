using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameInput : MonoBehaviour
{
    private PlayZoneTrigger currentZone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayZoneTrigger zone = collision.GetComponent<PlayZoneTrigger>();
        if (zone != null)
        {
            currentZone = zone;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayZoneTrigger zone = collision.GetComponent<PlayZoneTrigger>();
        if (zone != null && zone == currentZone)
        {
            currentZone = null;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            EnterMiniGame();
        }
    }

    private bool CanEnterMiniGame()
    {
        return true;
    }

    private void EnterMiniGame()
    {
        Debug.Log($"[MiniGameInput] EnterMiniGame ȣ��");

        Debug.Log($"GameManager.instance: {(GameManager.instance == null ? "NULL" : "OK")}");
        Debug.Log($"currentZone: {(currentZone == null ? "NULL" : "OK")}");

        if (GameManager.instance == null || currentZone == null)
        {
            Debug.LogError("EnterMiniGame ȣ�� ���� - �� �α� Ȯ��");
            return;
        }

        GameManager.instance.EnterMiniGame(currentZone.targetScene);
    }

}
