using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    float destroyTime = 2f;
    private Vector2 Dir;
    void Start()
    {
        Destroy(gameObject, destroyTime);

    }

}
