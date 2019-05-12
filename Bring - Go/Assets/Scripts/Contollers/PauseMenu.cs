//This script is for executing the functions of the pause menu.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool gameIsPaused = false;

    public void resume(){
        Time.timeScale = 1f;                //frame rate is normal
        gameIsPaused = false;
    }

    public void pause(){
        Time.timeScale = 0f;                //frame rate is 0
        gameIsPaused = true; 
    }

    public void getMainMenu(){
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Menu");         //Load the main menu scene
        }
    }

    public void quit(){
        Application.Quit();
    }

}
