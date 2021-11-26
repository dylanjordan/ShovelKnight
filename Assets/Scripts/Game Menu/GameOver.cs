using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;
    
    Player player;

    // Update is called once per frame
    void Update()
    {
        if (player._currentHealth == 0)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            gameOver.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
