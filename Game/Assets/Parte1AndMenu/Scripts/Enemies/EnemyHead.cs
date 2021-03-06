using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHead : MonoBehaviour
{
    [SerializeField] private float damage;

    private Animator anim;

    Rigidbody2D rb;
    public float distance;    
    bool Fall = false;      //enemy isn't falling
    BoxCollider2D boxCollider2D;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

     private void Update()
    {
        Physics2D.queriesStartInColliders = false;
        if (Fall == false)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distance);
            Debug.DrawRay(transform.position, Vector2.down * distance, Color.red);
            
            if(hit.transform != null )
            {
                if(hit.transform.tag == "Player")   //if Cassandra is walking under the enemy, enemy gravity scale increases
                {                                            
                    rb.gravityScale = 6;
                    Fall = true;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            anim.SetTrigger("Destroy");
            Destroy(gameObject, 1f);
            collision.GetComponent<Health>().TakeDamage(damage);      //Cassandra is hurt or dies
        }
        else
        {
            rb.gravityScale = 0;
          
        }
    }







}

