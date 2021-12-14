using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    public Rigidbody2D bullet;
    public float bulletSpeed = 15f;
    public int damage = 5;
    float destroyTime = 10f;

    // Start is called before the first frame update
    public void Start()
    {
        bullet.velocity = transform.right * bulletSpeed;
        Destroy(gameObject, destroyTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
