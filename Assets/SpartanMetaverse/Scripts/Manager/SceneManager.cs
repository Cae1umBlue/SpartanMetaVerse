using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Scenes
{
    MainScene,
    FlappyPlane,
    TheStack
}
public class SceneManager : MonoBehaviour
{
    public static SceneManager instance {  get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(Scenes scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene.ToString());
    }

}
