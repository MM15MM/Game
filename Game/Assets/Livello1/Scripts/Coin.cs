using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            PlayerManager.numberOfCoins++;  // number of coins increases by one whenever Cassandra picks up a coin
            Destroy(gameObject);
        }
    }
}
