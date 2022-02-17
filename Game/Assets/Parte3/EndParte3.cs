using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndParte3 : MonoBehaviour
{
    public GameObject RecapScreen;
    public Text HighscoreTextRecap;
    public Text ScoreTextRecap;
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
        ScoreText.SetActive(false);
        HighscoreTextRecap.text = "Highscore: " + PlayerPrefs.GetInt("highscore", 0).ToString();
        ScoreTextRecap.text = "Score: " + PlayerPrefs.GetInt("score", 0).ToString();

    }
}
