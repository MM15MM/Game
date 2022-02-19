using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Screens")]
    public GameObject SettingsScreen;
    public GameObject LoginScreen;
    public GameObject MenuScreen;
    public void Play()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void Settings()
    {
  
        SettingsScreen.SetActive(true);


    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void Login()
    {
        LoginScreen.SetActive(true);
        MenuScreen.SetActive(false);
    }
    public void QuitLoginScreen()
    {
        LoginScreen.SetActive(false);
        MenuScreen.SetActive(true);
    }
}
