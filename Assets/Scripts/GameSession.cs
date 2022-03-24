using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameSession : MonoBehaviour
{
    int currentIndex;
    void Start()
    {
        currentIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(currentIndex);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if(Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene(0);
        }
    }
    public void LoadNextLevel()
    {
        if (currentIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(currentIndex + 1);
        }
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(currentIndex);
    }
}
