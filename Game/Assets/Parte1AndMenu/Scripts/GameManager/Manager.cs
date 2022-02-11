using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public static Manager instance;

    public static int numberOfCoins;  //number of coins
    public TextMeshProUGUI coinsText;

    public GameObject PauseScreen;

    public static bool gameOver;
    public GameObject gameOverScreen;

    public int scorePoints;

    //static public float CassandraHealth;

    //public ScoreScript ss;
    public Text HighscoreTextRecap;

    public GameObject HighscoreText;
    public GameObject ScoreText; 


    private void Awake()
    {
        instance = this;
        Time.timeScale = 1;
        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        //scorePoints = PlayerPrefs.GetInt("score", 0);
        //CassandraHealth = PlayerPrefs.GetFloat("CurrentHealth", 0);
        
        gameOver = false;
    }

    void Update()
    {
        coinsText.text = numberOfCoins.ToString(); 

        if(gameOver)
        {
            Time.timeScale = 0;
            gameOverScreen.SetActive(true);
            HighscoreText.SetActive(false);
            ScoreText.SetActive(false);

            //HighscoreTextRecap.text = "Highscore: " + ss.highscore.ToString();

            ScoreScript ss = ScoreText.GetComponent<ScoreScript>();

            if (ss.highscore < ss.score) ss.highscore = ss.score;
            HighscoreTextRecap.text = "Highscore: " + ss.highscore.ToString();
            //HighscoreTextRecap.text = "Highscore: " + ss.highscore.ToString();
        }

    }
    public void Pause()
    {
        Time.timeScale = 0;
        PauseScreen.SetActive(true);
       

    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Reset();
    }
    public void Resume()
    {
        Time.timeScale = 1;
        PauseScreen.SetActive(false);
        
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene("Parte1");
        Reset();
    }

    public void Reset()
    {
        PlayerPrefs.SetInt("NumberOfCoins", 0);
        PlayerPrefs.SetInt("score", 0);
    }
}
