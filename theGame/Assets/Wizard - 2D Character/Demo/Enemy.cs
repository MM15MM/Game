using ClearSky;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 15;
    public Animator deathAnim;
    public int damage = 3;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        deathAnim.SetTrigger("Colpito");
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SimplePlayerController player = collision.GetComponent<SimplePlayerController>();
        if (player != null)
        {
            player.Hurt(damage);
        }
    }
}
