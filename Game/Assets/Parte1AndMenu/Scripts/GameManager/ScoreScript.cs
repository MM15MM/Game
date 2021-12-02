using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static ScoreScript instance;
    public Text scoreText;
    int score = 0;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;

    }
    void Start()
    {
        scoreText.text = "Score: " + score.ToString();
        score = 0;

    }
    public void AddPoint()
    {
        score += 1;
        scoreText.text = "Score: " + score.ToString();
        PlayerPrefs.SetInt("Score", score);
    }
    public void AddPoints()
    {
        score += 5;
        scoreText.text = "Score: " + score.ToString();
        PlayerPrefs.SetInt("Score", score);
    }
}
