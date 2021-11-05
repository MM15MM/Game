using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform mainCam;
    public Transform middleBG;
    public Transform sideBG;

    public float length = 22.399859f;

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