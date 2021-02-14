using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text scoreText; //Основные очки
    static int score;
    public int valueScore
    {
        get { return score; }
        set
        {
            score = value;
            scoreText.text = score.ToString();
        }
    }
    void Start()
    {
        score = 0;
    }
}
