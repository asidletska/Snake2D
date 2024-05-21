using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class panelGameOver : MonoBehaviour
{
    public void OnPlayerHandler()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
    }
    public void MenuPlayerHandler()
    {
        SceneManager.LoadScene(0);
    }
}
