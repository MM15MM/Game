using UnityEngine;

public class EnemyAttack3 : MonoBehaviour
{
    [SerializeField] private float damage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")                                 //If Cassandra touches the dragon, Cassandra healt -1
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }
}