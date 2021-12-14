using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class SceneManagerTransitions : MonoBehaviour
{
    public Animator transitionanimator_;
    public Animator musicAnim;
    public string nameOfScene;
    public float waitTime;
    public float TransitionTime = 1f;


    void Awake()
    {
        transitionanimator_ = GameObject.Find("Transition").GetComponent<Animator>();
    }
    void update() {
        if ((CrossPlatformInputManager.GetButtonDown("PlayButton")) || (CrossPlatformInputManager.GetButtonDown("MainMenu"))) {
            LoadTheScene();                              //load scene with tansition
        }
    }

    public void LoadTheScene()
    {
        StartCoroutine(LoadScene());
    }
    IEnumerator LoadScene()
    {
        musicAnim.SetTrigger("FadeOut");
        yield return new WaitForSeconds(waitTime);
        transitionanimator_.SetTrigger("Start");
        yield return new WaitForSeconds(TransitionTime);
        SceneManager.LoadScene(nameOfScene);
    }
}
