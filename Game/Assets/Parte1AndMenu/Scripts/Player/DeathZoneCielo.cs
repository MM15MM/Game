using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneCielo : MonoBehaviour
{
    [SerializeField] private float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")                                 //If Cassandra falls, she dies
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
