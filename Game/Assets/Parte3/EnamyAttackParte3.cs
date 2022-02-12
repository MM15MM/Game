using UnityEngine;

public class EnemyAttackParte3: MonoBehaviour
{
    [SerializeField] private float damage;
    private void OnCollisionEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")                                 //If Cassandra touches the dragon, Cassandra healt -1
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}

