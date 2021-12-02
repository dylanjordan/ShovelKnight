using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenu : MonoBehaviour
{
    public bool newGame;
   public void PlayGame()
    {
        // this loads the testscene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        newGame = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
