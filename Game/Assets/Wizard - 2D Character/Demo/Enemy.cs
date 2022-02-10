using ClearSky;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 15;
    public Animator deathAnim;

    void Update()
    {

    }
    public void TakeDamage(int damage)
    {
        deathAnim.SetBool("Hurt", true);
        health -= damage;
        if (health <= 0)
        {
            deathAnim.SetBool("isDead", true);
            Destroy(gameObject);
            ScoreScript.instance.AddPoints();
        }
        deathAnim.SetBool("Hurt", false);
    }

}
