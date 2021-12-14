using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDamage : MonoBehaviour
{
    [SerializeField] private int damage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
