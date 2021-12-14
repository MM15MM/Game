using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    public static int numberOfCoins;  //number of coins
    public TextMeshProUGUI coinsText;

    public GameObject PauseScreen;

    public static bool gameOver;
    public GameObject gameOverScreen;

    public static int scorePoints;

 


    private void Awake()
    {
        Time.timeScale = 1;
        //numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
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
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
