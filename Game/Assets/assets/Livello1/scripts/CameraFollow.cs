using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform PlayerTransform;
    public float offset;
    void Start()
    {
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        Vector3 temp = transform.position;
        temp.x = PlayerTransform.position.x;
        temp.y = PlayerTransform.position.y;

        temp.x += offset;
        temp.y += offset;

        transform.position = temp;
    }
}