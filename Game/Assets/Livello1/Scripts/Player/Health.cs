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
    public void TakeDamage (float damage)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, StartingHealth);

        if (CurrentHealth > 0)
        {
            anim.SetTrigger("Hurt");
            AudioManager.instance.Play("Hurt");
        }
        else
        {
            if (!dead)
            {    //Cassandra
                anim.SetTrigger("Die");
                if (GetComponent<PlayerMov>() != null)
                {
                    GetComponent<PlayerMov>().enabled = false;

                    //Game Over
                    Manager.gameOver = true;
                    gameObject.SetActive(false);
                    AudioManager.instance.Play("Game Over");
                }
                //Knight
                if (GetComponentInParent<EnemyBehaviour>() != null)
                {
                    GetComponentInParent<EnemyBehaviour>().enabled = false;
                    if (GetComponent<EnemyAttack>() != null)
                        GetComponent<EnemyAttack>().enabled = false;
                    Destroy(gameObject);
                        
                }
                    dead = true;
            }

        }
    }

    public void AddHealth(float value)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + value, 0, StartingHealth);
        AudioManager.instance.Play("HeartCollected");
    }

   

}
