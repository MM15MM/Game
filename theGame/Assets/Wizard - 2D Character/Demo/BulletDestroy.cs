using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    public Rigidbody2D bullet;
    public float bulletSpeed = 15f;

    public int damage = 5;
    float destroyTime = 15f;

    // Start is called before the first frame update
    public void Start()
    {
        bullet.velocity = transform.right * bulletSpeed;
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null) {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
