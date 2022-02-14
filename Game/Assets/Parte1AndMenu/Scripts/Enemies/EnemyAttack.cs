using UnityEngine;

public class EnemyAttack : MonoBehaviour
{ 
    [SerializeField] private float damage;
       private void OnTriggerEnter2D(Collider2D collision)
       {
        if (collision.tag == "Player")                                 //If Cassandra touches the dragon, Cassandra healt -1
        {                                                             
            collision.GetComponent<Health>().TakeDamage(damage);
            //PlayerPrefs.SetFloat("CurrentHealth", Manager.CassandraHealth);
        }
       }
}
