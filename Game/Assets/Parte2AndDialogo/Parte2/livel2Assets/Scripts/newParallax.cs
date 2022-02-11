using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newParallax : MonoBehaviour
{
    public Transform mainCam;
    public Transform middleBG;
    public Transform sideBG;

    public float length = 11.88f;

    // Update is called once per frame
    void Update()
    {
        if (mainCam.position.x > middleBG.position.x)
        {
            sideBG.position = middleBG.position + Vector3.right * length;
        }
        else
      if (mainCam.position.x < middleBG.position.x)
        {
            sideBG.position = middleBG.position + Vector3.left * length;
        }
        if (mainCam.position.x > sideBG.position.x || mainCam.position.x < sideBG.position.x)
        {
            Transform c = middleBG;
            middleBG = sideBG;
            sideBG = c;
        }
    }
}
