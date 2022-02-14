using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float StartingHealth;
    private Animator anim;
    private bool dead;
    public float CurrentHealth { get; private set; }

   


    private void Awake()
    {
        CurrentHealth = StartingHealth;
        anim = GetComponent<Animator>();
       

    }

    public void TakeDamage(float damage)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, StartingHealth);

        if (CurrentHealth > 0)
        {
            anim.SetTrigger("Hurt");
            AudioManager.instance.Play("Hurt");
            StartCoroutine("GetInvulnerable");
        }
        else
        {
            if (!dead)
            {    //Cassandra
                anim.SetTrigger("Die");
                if (GetComponent<PlayerMov>() != null)
                {
                    GetComponent<PlayerMov>().enabled = false;
                    dead = true;

                    //Game Over
                    Manager.gameOver = true;
                    Destroy(gameObject, 2f);
                    AudioManager.instance.Play("Game Over");
                }
                //Dragon
                if (GetComponentInParent<EnemyBehaviour>() != null)
                {
                    GetComponentInParent<EnemyBehaviour>().enabled = false;
                    if (GetComponent<EnemyAttack>() != null)
                        GetComponent<EnemyAttack>().enabled = false;
                    dead = true;
                    Destroy(gameObject, 1f);
                    AudioManager.instance.Play("dragonDies");
                    ScoreScript.instance.AddPoint();

                }

            }

        }
    }

    public void AddHealth(float value)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + value, 0, StartingHealth);    //Cassandra's health increases by one if she collects an  heart
        AudioManager.instance.Play("Collected");
    }

    IEnumerator GetInvulnerable()
    {
        Physics2D.IgnoreLayerCollision(7, 8, true);
        yield return new WaitForSeconds(3f);
        //Physics2D.IgnoreLayerCollision(7, 8, false);
    }

}
