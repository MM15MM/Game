using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    float destroyTime = 0.5f;
    private Vector2 Dir;
    void Start()
    {
        Destroy(gameObject, destroyTime);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

       if (collision.tag == "Enemy")
            collision.GetComponent<Health>().TakeDamage(1);

    }

}
