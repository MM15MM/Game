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
        deathAnim.SetBool("Hurt", true);
        if (health <= 0)
        {
            Die();
        }
        deathAnim.SetBool("Hurt", false);
    }

    void Die()
    {
        deathAnim.SetBool("isDead", true);
        Destroy(gameObject);
    }
}
