using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndParte1 : MonoBehaviour
{
    public Animator Parte1animator_;
    public string nameOfScene;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(LoadScene());
        }


    }
    IEnumerator LoadScene()
    {
        Parte1animator_.SetTrigger("EndTransition");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(nameOfScene);
    }
}
