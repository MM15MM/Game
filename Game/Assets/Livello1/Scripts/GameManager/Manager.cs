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


    private void Awake()
    {
        gameOver = false;
    }

    void Update()
    {
        coinsText.text = numberOfCoins.ToString(); 

        if(gameOver)
        {
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        numberOfCoins = 0;
    }
}
