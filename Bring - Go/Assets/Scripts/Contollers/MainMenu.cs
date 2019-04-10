using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject scorePreFab;

    public void PlayGame()    //Start to play the game
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.DeleteKey("TmpScore");
    }

    public void showHighScore()               //executes the update method in HighScoreScript 
    {
        HighScoreScript.showHighScore();
    }
    
    public void QuitGame()      //Exit from the application
    {
        //Debug.Log("QUIT!");
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    
}