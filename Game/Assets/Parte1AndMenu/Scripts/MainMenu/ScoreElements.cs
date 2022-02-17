using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreElements : MonoBehaviour
{

    public TMP_Text usernameText;
    public TMP_Text scoreText;

    public void NewScoreElement(string _username, int _score)
    {
        usernameText.text = _username;
        scoreText.text = _score.ToString();
    }

}
