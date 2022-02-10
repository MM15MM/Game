using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public static int numberOfCoins;  //number of coins
    public TextMeshProUGUI coinsText;

    public GameObject PauseScreen;

    public static bool gameOver;
    public GameObject gameOverScreen;

    public static int scorePoints;

    //public ScoreScript ss;
    public Text HighscoreTextRecap;
    public GameObject HighscoreText;

    public GameObject ScoreText; 


    private void Awake()
    {
        Time.timeScale = 1;
        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        //scorePoints = PlayerPrefs.GetInt("PlayerScore", 0);
        gameOver = false;
    }

    void Update()
    {
        coinsText.text = numberOfCoins.ToString(); 

        if(gameOver)
        {
            Time.timeScale = 0;
            gameOverScreen.SetActive(true);
            //HighscoreTextRecap.text = "Highscore: " + ss.highscore.ToString();

            ScoreScript ss = ScoreText.GetComponent<ScoreScript>();
            if (ss.highscore < ss.score) ss.highscore = ss.score;
            else 
            HighscoreTextRecap.text = "Highscore: " + ss.highscore.ToString();
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
    }
    public void Resume()
    {
        Time.timeScale = 1;
        PauseScreen.SetActive(false);
        
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
