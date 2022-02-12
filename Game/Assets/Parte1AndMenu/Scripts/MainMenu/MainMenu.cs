using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject SettingsScreen;
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
}
