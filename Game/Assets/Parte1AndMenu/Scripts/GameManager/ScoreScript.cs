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
    public int highscore;
    public int score;
    
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;

    }
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        score = PlayerPrefs.GetInt("score", 0);
        scoreText.text = "Score: " + score.ToString();
        HighscoreText.text = "Highscore: " + highscore.ToString();

    }
    private void OnDestroy()
    {
        PlayerPrefs.SetInt("higscore", highscore);
        PlayerPrefs.SetInt("score", score);
    }
    public void AddPoint()
    {
        score += 1;
        scoreText.text = "Score: " + score.ToString();
        updateHighscore();
        PlayerPrefs.SetInt("score", score);

        //if (highscore < score)
            //PlayerPrefs.SetInt("highscore", score);
    }

    void updateHighscore()
    {
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("highscore", score);

        }
    }
 public void ResetScore()
    {
        score = 0;
    }
}
