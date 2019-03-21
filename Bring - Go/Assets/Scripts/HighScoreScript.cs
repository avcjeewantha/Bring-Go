using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System;
using System.Data;

public class HighScoreScript : MonoBehaviour
{
    public GameObject score; 
    private static string connectionString;
    public static String _score;
    private static HighScore highscore;

    void Update()   //Update the high Score (text)    // Update is called once per frame
    {
        this.score.GetComponent<Text>().text = _score;
    }

    public static void showHighScore()               //executes the update method in HighScoreScript 
    {
        connectionString = "URI=file:" + Application.dataPath + "/HighScoreDB.sqlite";
        highscore = null;

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
                        highscore = new HighScore(reader.GetInt32(0));   //Create a new High Score Object
                        //Debug.Log(this.highscore.score.ToString());
                    }
                    dbConnection.Close();
                    reader.Close();
                }
            }
        }
        _score = highscore.score.ToString();
    }

    public void insertScore(int newScore)   //Insert new scores to database
    {
        connectionString = "URI=file:" + Application.dataPath + "/HighScoreDB.sqlite";
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = String.Format("INSERT INTO HighScore(score) VALUES(\"{0}\"", newScore);
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();
            }
        }
    }

    private void deleteScoreFromDB(int oldScore)   // can delete specific score from database
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = String.Format("DELETE FROM HighScore WHERE score = \"{0}\"", oldScore);
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();
            }
        }
    }

}
 