using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float StartingHealt;
    private Animator anim;
    private bool dead;
    public float CurrentHealth { get; private set; }
   

    private void Awake()
    {
        CurrentHealth = StartingHealt;
        anim = GetComponent<Animator>();

    }
    public void TakeDamage (float _damage)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - _damage, 0, StartingHealt);

        if (CurrentHealth > 0)
        {
            anim.SetTrigger("Hurt");
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("Die");
                GetComponent<PlayerMov>().enabled = false;
                dead = true;
            }

        }
    }

}
