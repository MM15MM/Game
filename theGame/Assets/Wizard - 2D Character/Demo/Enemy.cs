using ClearSky;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 15;
    public Animator deathAnim;

    public void TakeDamage(int damage)
    {
        deathAnim.SetBool("Hurt", true);
        health -= damage;
        if (health <= 0)
        {
            Die();
            Destroy(gameObject);
        }
        deathAnim.SetBool("Hurt", false);
    }

    void Die()
    {
        deathAnim.SetBool("isDead", true);
    }
}
