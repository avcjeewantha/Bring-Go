//This script is for managing the highScore part of the game.

using System;
using Mono.Data.Sqlite;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using TMPro;

public class HighScoreScript : MonoBehaviour {
    public TextMeshProUGUI score;
    public static int _score;

    void Update () //Update the high Score (text)    // Update is called once per frame
    {
        this.score.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("HighScore").ToString();  //Always update the value of highScore panel according to the highScore value stored in device's registers.
    }

    public static void showHighScore()                          //executes the update method in HighScoreScript 
    {
        string filepath = Application.dataPath + "/Database/HighScoreDB.sqlite";
        string conn = "URI=file:" + filepath;

        using (IDbConnection dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();                                       //Open connection to the database.
            IDbCommand dbcmd = dbconn.CreateCommand();
            string sqlQuery = "SELECT MAX(score) FROM HighScore";//DELETE FROM HighScore WHERE scoreID > 1;
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                _score = reader.GetInt32(0);
                _score = PlayerPrefs.GetInt("HighScore");
                //Debug.Log(_score);
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
        }
    }

    public static void insertScore(int newScore)                    //Insert new scores to database
    {
        string filepath = Application.dataPath + "/Database/HighScoreDB.sqlite";
        string conn = "URI=file:" + filepath;

        if (PlayerPrefs.GetInt("HighScore") < newScore)
        {
            PlayerPrefs.SetInt("HighScore", newScore);              //Change the highScore if the score value exceeds the highScore value.
        }

            using (IDbConnection dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            IDbCommand dbcmd = dbconn.CreateCommand();
            string sqlQuery = string.Format("INSERT INTO HighScore(score) VALUES(" + newScore + ")");
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }

    //private static void deleteScoreFromDB (int oldScore) // can delete specific score from database
    //{
    //    using (IDbConnection dbConnection = new SqliteConnection (connectionString)) {
    //        dbConnection.Open ();

    //        using (IDbCommand dbCmd = dbConnection.CreateCommand ()) {
    //            string sqlQuery = String.Format ("DELETE FROM HighScore WHERE score = " + oldScore );
    //            dbCmd.CommandText = sqlQuery;
    //            dbCmd.ExecuteScalar ();
    //            dbConnection.Close ();
    //        }
    //    }

}