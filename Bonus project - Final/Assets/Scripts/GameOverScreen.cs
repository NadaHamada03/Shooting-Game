using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Enemy _enemy;

    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        Enemy.kills = 0;
        SceneManager.LoadScene("Level 1");
    }

    public void MainMenuButton()
    {
        Enemy.kills = 0;
        SceneManager.LoadScene(0);
    }
}
