using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class MainMenu : MonoBehaviour
{
    private string connectionString;

    public void highScore()
    {
        connectionString = "URI=file:" + Application.dataPath + "/HighScoreDB.sqlite";
        getHighScoreFromDB();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }   

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }





























    private void getHighScoreFromDB()
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT MAX(score) FROM HighScore";
                dbCmd.CommandText = sqlQuery;

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Debug.Log(reader.GetValue(0));                       
                    }
                    dbConnection.Close();
                    reader.Close();
                }
            }
        }
    }
    
}