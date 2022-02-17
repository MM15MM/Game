using UnityEngine;

public class EnemyAttack : MonoBehaviour
{ 
    [SerializeField] private float damage;
       private void OnTriggerEnter2D(Collider2D collision)
       {
        if (collision.tag == "Player")                                 //If Cassandra touches the dragon or the enemy, Cassandra's healt decreases
        {                                                             
            collision.GetComponent<Health>().TakeDamage(damage);
        }
       }
}
