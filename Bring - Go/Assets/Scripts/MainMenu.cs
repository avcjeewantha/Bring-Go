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
    private HighScore highscore;
    public GameObject scorePreFab;
    public static String score;

    public void highScore()
    {
        connectionString = "URI=file:" + Application.dataPath + "/HighScoreDB.sqlite";
        getHighScoreFromDB();
    }

    public void insertScore(int newScore)
    {
        connectionString = "URI=file:" + Application.dataPath + "/HighScoreDB.sqlite";
        insertScoreToDB(newScore);
    }

    public void showHighScore()
    {
        highScore();
        score = this.highscore.score.ToString();
        //Debug.Log(this.highscore.score.ToString());
        //GameObject tmpObjec = Instantiate(scorePreFab);
        //tmpObjec.transform.SetParent(, false);
        //Debug.Log("chhsd");
       // HighScore tmpScore = this.highscore;
        //Debug.Log(tmpScore.score.ToString());
       // tmpObjec.GetComponent<HighScoreScript>().setScore(tmpScore.score.ToString());
    }


    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }   

    public void QuitGame()
    {
        //Debug.Log("QUIT!");
        Application.Quit();
    }

    private void getHighScoreFromDB()
    {
        this.highscore = null;

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
                        this.highscore = new HighScore(reader.GetInt32(0));
                        //Debug.Log(this.highscore.score.ToString());
                    }
                    dbConnection.Close();
                    reader.Close();
                }
            }
        }
    }

    private void insertScoreToDB(int newScore)
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = String.Format("INSERT INTO HighScore(score) VALUES(\"{0}\"",newScore);
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();
            }
        }
    }

    private void deleteScoreFromDB(int oldScore)
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = String.Format("DELETE FROM HighScore WHERE score = \"{0}\"", oldScore );
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();
            }
        }
    }
    
}