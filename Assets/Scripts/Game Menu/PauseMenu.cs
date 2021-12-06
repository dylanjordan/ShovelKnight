 using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject optionMenu;
    public GameObject settingMenu;
    public GameObject controlsMenu;
    public static bool isPaused = false;
    public static bool isOption = false;
    
    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    
   public void PauseGame()
    {
        pauseMenu.SetActive(true);
        isPaused = true;

        if (settingMenu.activeInHierarchy)
        {
            settingMenu.SetActive(false);
        }

        if (controlsMenu.activeInHierarchy)
        {
            controlsMenu.SetActive(false);
        }

        if (optionMenu.activeInHierarchy)
        {
            optionMenu.SetActive(false);
        }
     

    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuTest");
        isPaused = false;
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }    
}
