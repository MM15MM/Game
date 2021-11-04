using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D rb;
    private Vector2 Dir;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("DestroySelf", .5f);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.velocity = Dir * Speed; 
    }
    public void SetDirection(Vector2 dir)
    {
        Dir = dir;
    }
    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
