using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameEndHandler : MonoBehaviour
{
    public int score;

    public void EndMiniGame()
    {
        PlayerPrefs.SetInt("LastMiniGameScore", score); // 점수 저장
        PlayerPrefs.Save();

        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMap");
    }
}
