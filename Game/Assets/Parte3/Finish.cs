using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public string NameOfScene;
    public void GoToFinalDialogue()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(NameOfScene);
    }


}
