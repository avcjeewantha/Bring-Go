using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour
{
    public GameObject score;

    //public void setScore(string score)
    //{
      //  this.score.GetComponent<Text>().text = score;
        //Debug.Log(score);
    //}
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        this.score.GetComponent<Text>().text = MainMenu.score;
    }

}
 