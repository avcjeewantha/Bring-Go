using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool gameIsPaused = false;

    public void resume(){
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void pause(){
        Time.timeScale = 0f;
        gameIsPaused = true; 
    }

    public void getMainMenu(){
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Menu");
        }
    }

    public void quit(){
        Application.Quit();
    }

}
