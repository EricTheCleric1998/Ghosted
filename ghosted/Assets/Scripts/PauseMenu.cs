using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;
    public GameObject escape;
    bool escapeEnabled;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void clickESC()
   {
       escapeEnabled = !escapeEnabled;
       if(escapeEnabled == true)
       {
           escape.SetActive(true);
       }else
       {
           escape.SetActive(false);
       }
   }

    public void ExitToMenu()
    {
        Debug.Log("Loading menu...");
        SceneManager.LoadScene("StartScene");
        Time.timeScale = 1f;
    }
}

