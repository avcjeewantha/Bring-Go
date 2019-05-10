using System;
using Mono.Data.Sqlite;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using TMPro;

public class HighScoreScript : MonoBehaviour {
    public TextMeshProUGUI score;
    //private static string connectionString;
    public static int _score;
    //public GameObject score;
    //IDbCommand dbcmd;
    //private IDataReader reader;
    //public Text data_staff;

    //string DatabaseName ="HighScoreDB.sqlite";



    void Update () //Update the high Score (text)    // Update is called once per frame
    {
        this.score.GetComponent<TextMeshProUGUI>().text = _score.ToString();
    }


    public static void showHighScore() //executes the update method in HighScoreScript 
    {
        string filepath = Application.dataPath + "/Plugins/HighScoreDB.sqlite";
        string conn = "URI=file:" + filepath;

        using (IDbConnection dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            IDbCommand dbcmd = dbconn.CreateCommand();
            string sqlQuery = "SELECT MAX(score) FROM HighScore";//DELETE FROM HighScore WHERE scoreID > 1;
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                _score = reader.GetInt32(0);
                //Debug.Log(_score);

            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
        }
    }

    public static void insertScore(int newScore) //Insert new scores to database
    {
        string filepath = Application.dataPath + "/Plugins/HighScoreDB.sqlite";
        string conn = "URI=file:" + filepath;

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