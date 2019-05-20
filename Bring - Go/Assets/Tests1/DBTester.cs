using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;

public class DBTester : MonoBehaviour
{
    public void checkDB()
    {
        string filepath = Application.dataPath + "/Database/HighScoreDB.sqlite";
        if (!File.Exists(filepath))
        {
            Debug.Log("Database not in Persistent path");
        }
        else
        {
            Debug.Log("DB Test - Success");
        }
    }

    public void insertionTest()
    {
        for (int i = 0; i < 10; i++)
        {
            HighScoreScript.insertScore(1);
        }
    }

    public void readData()
    {
        string filepath = Application.dataPath + "/Database/HighScoreDB.sqlite";
        string conn = "URI=file:" + filepath;

        using (IDbConnection dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();                                   
            IDbCommand dbcmd = dbconn.CreateCommand();
            string sqlQuery = "SELECT score FROM HighScore ORDER BY scoreID DESC LIMIT 10;";//DELETE FROM HighScore WHERE scoreID > 1;
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                int score = reader.GetInt32(0);
                Debug.Log(score);
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
        }
    }

    void OnEnable()
    {
        checkDB();
        insertionTest();
        readData();
        Debug.Log("Insertion Test- Success");
    }
}

