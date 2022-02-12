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
    public Text HighscoreText;

    [Header("Score values")]
    public int highscore;
    public int score;


    
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        //PlayerPrefs.SetInt("score", score);
    }
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        score = PlayerPrefs.GetInt("score", 0);
        scoreText.text = "Score: " + score.ToString();
        HighscoreText.text = "Highscore: " + highscore.ToString();

    }
    /*private void OnDestroy()
    {
        PlayerPrefs.SetInt("higscore", highscore);
        PlayerPrefs.SetInt("score", score);
    }*/
    public void AddPoint()
    {
        score += 1;
        scoreText.text = "Score: " + score.ToString();
        PlayerPrefs.SetInt("score", score);
        updateHighscore();
        

        /*if (highscore < score)
            PlayerPrefs.SetInt("highscore", score);*/
    }

    void updateHighscore()
    {
        if (score > highscore)
        {
            //highscore = score;
            PlayerPrefs.SetInt("highscore", score);

        }
    }

   /* public void Reset()
    {
        score = 0;
        PlayerPrefs.SetInt("score", 0);
    }*/

}
