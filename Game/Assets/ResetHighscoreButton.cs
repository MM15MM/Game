using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetHighscoreButton : MonoBehaviour
{
    public void ResetHighscore()
    {
        PlayerPrefs.SetInt("highscore", 0);
    }
}
