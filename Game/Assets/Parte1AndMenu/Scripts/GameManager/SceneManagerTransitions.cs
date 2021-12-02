using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class SceneManagerTransitions : MonoBehaviour
{
    public Animator transitionanimator_;
    public Animator musicAnim;
    public string nameOfScene;
    public float waitTime;
    void update() {
        if (CrossPlatformInputManager.GetButtonDown("PlayButton")) {
            StartCoroutine(LoadScene());                              //If the game starts, load the next scene with tansition
        }
    }
    IEnumerator LoadScene()
    {
        musicAnim.SetTrigger("FadeOut");
        yield return new WaitForSeconds(waitTime);
        transitionanimator_.SetTrigger("EndTransition");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(nameOfScene);
    }
}
