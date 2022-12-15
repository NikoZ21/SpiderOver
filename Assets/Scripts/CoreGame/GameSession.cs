using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameSession : MonoBehaviour
{

    private int _currentIndex;


    void Start()
    {
        _currentIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        QuitApplication();
        ResetGame();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level One");
    }

    private void QuitApplication()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void ResetGame()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void LoadNextLevel()
    {
        if (_currentIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(_currentIndex + 1);
        }
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(_currentIndex);
    }
}
