using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    int currentScene;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

  
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(currentScene + 1);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(currentScene);
    }

    public void QuitGame()
    {
        //Application.Quit(); for pc builds only
        Debug.Log(" You Quit");
    }
}
