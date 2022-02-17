using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static ScoreScript instance;

    public static int s;

    [Header ("Score text")]
    public Text scoreText;

    [Header("Score values")]
    public int highscore;
    public int score;


    
    void Awake()
    {
        instance = this;
 
    }
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        score = PlayerPrefs.GetInt("score", 0);
        scoreText.text = "Score: " + score.ToString();

    }
 
    public void AddPoint()
    {
        score += 1;
        scoreText.text = "Score: " + score.ToString();
        PlayerPrefs.SetInt("score", score);
        updateHighscore();

    }

    void updateHighscore()
    {
        if (score > highscore)
        {
            PlayerPrefs.SetInt("highscore", score);

        }
    }


}
