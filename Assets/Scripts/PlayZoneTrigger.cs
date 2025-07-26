using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayZoneTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("게임존 입장");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("게임존 퇴장");
        }
    }
}

public class MiniGameInput : MonoBehaviour
{
    public string miniGameName = "The Stack";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
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
        UnityEngine.SceneManagement.SceneManager.LoadScene(miniGameName);
    }
}
