using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameEndHandler : MonoBehaviour
{
    public int score;

    public void EndMiniGame()
    {
        PlayerPrefs.SetInt("LastMiniGameScore", score); // ���� ����
        PlayerPrefs.Save();

        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMap");
    }
}
