using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndParte2 : MonoBehaviour
{
    public string nameOfScene;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            AudioManager.instance.Play("Teleport");
            Invoke("Change", 0.25f);
        }


    }
    private void Change()
    {
        SceneManager.LoadScene(nameOfScene);
    }
}

