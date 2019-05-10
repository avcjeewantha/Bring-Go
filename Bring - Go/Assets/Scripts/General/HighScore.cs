using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public int score { get; set; }

    public HighScore(int score)         //High score Object / class
    {
        this.score = score;
    }
}
