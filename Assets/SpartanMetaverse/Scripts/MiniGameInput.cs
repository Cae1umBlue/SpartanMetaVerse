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
        GameManager.instance.ChangeScene(currentZone.targetScene);
    }

}
