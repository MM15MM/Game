using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static ScoreScript instance;

    [Header ("Score text")]
    public Text scoreText;
    public Text HighscoreText;

    [Header("Score values")]
    int highscore = 0;
    int score = 0;
    
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;

    }
    void Start()
    {
        highscore = PlayerPrefs.GetInt("Highscore", 0);
        scoreText.text = "Score: " + score.ToString();
        HighscoreText.text = "Highscore: " + highscore.ToString();
        score = 0;

    }
    public void AddPoint()
    {
        score += 1;
        scoreText.text = "Score: " + score.ToString();
        PlayerPrefs.SetInt("Score", score);
        if (highscore < score)
            PlayerPrefs.SetInt("highscore", score);
    }
    public void AddPoints()
    {
        score += 5;
        scoreText.text = "Score: " + score.ToString();
        PlayerPrefs.SetInt("Score", score);
    }
}
