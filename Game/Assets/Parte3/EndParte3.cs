using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndParte3 : MonoBehaviour
{
    public GameObject RecapScreen;
    public Text HighscoreTextRecap;
    public GameObject HighscoreText;
    public GameObject ScoreText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            AudioManager.instance.Play("Teleport");
            Invoke("Recap", 0.25f);

        }


    }

    private void Recap()
    {
        Time.timeScale = 0;
        RecapScreen.SetActive(true);
        HighscoreText.SetActive(false);
        ScoreScript ss = ScoreText.GetComponent<ScoreScript>();

        if (ss.highscore < ss.score) ss.highscore = ss.score;
        HighscoreTextRecap.text = "Highscore: " + ss.highscore.ToString();

    }
}
