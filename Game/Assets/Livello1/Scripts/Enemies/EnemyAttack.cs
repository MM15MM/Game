using UnityEngine;

public class EnemyAttack : MonoBehaviour
{ 
    [SerializeField] private float damage;
       private void OnTriggerEnter2D(Collider2D collision)
       {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
       }
}
