using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public static Manager instance;

    [Header("Coins")]
    public static int numberOfCoins;  //number of coins
    public TextMeshProUGUI coinsText;

    [Header("Screens")]
    public GameObject PauseScreen;

    public static bool gameOver;
    public GameObject gameOverScreen;


    [Header("Score Texts")]
    public Text HighscoreTextRecap;
    public Text ScoreTextRecap;
    public GameObject ScoreText; 


    private void Awake()
    {
        instance = this;
        Time.timeScale = 1;
        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);

        gameOver = false;
    }


    void Update()
    {
        coinsText.text = numberOfCoins.ToString();

        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverScreen.SetActive(true);
            ScoreText.SetActive(false);
            ScoreTextRecap.text = "Score: " + PlayerPrefs.GetInt("score", 0).ToString();
            HighscoreTextRecap.text = "Highscore: " + PlayerPrefs.GetInt("highscore", 0).ToString();
        }

    }
    public void Pause()
    {
        Time.timeScale = 0;
        PauseScreen.SetActive(true);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
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
