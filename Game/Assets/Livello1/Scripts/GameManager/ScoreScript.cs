using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    Text scoreText;
    public static int score = 0;
    // Start is called before the first frame update
    void Awake()
    {
        scoreText = GetComponent<Text>();
        score = 0;

    }

    void update()
    {
       
       scoreText.text = "Score:" + score;
        //PlayerPrefs.SetInt("PlayerScore", Manager.scorePoints);
    }
}
