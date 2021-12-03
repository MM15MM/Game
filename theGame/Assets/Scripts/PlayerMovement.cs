﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    float speed;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() 
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        speed = 3.0f;

        Vector2 position = transform.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + 1.5f * speed * vertical * Time.deltaTime;
        transform.position = position;

        if (horizontal < 0) body.transform.localScale = new Vector3 (-1, 1, 1);
        else body.transform.localScale = new Vector3 (1, 1, 1);

        anim.SetFloat("isMoving", Mathf.Abs(speed * horizontal));

        anim.SetBool("isJumping", Mathf.Abs(vertical)>0);
        
    }
}