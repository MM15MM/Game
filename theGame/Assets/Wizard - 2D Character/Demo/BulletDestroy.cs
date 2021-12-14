using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    public Rigidbody2D bullet;
    public float bulletSpeed = 15f;
    float destroyTime = 5f;

    // Start is called before the first frame update
    public void Start()
    {
        bullet.velocity = transform.right * bulletSpeed;
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
