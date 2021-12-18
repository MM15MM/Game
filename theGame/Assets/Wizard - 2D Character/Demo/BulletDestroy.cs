using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    public Rigidbody2D bullet;
    public float bulletSpeed = 15f;

    public int damage = 5;

    public void Start()
    {
        bullet.velocity = transform.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null) {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
