using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayZoneTrigger : MonoBehaviour
{
    public Scenes targetScene = Scenes.TheStack;
    private bool isPlayerInside = false; // 플레이어가 플레이존에 들어왔는지 유무

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInside = true;
            Debug.Log("게임존 입장");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInside = false;
            Debug.Log("게임존 퇴장");
        }
    }

    public bool IsPlayerInside() => isPlayerInside;
}
