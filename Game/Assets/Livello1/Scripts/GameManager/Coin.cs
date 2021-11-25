using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            ScoreScript.score++;
            Manager.numberOfCoins++;  // number of coins increases by one whenever Cassandra picks up a coin
            AudioManager.instance.Play("Coin");
            //PlayerPrefs.SetInt("NumberOfCoins", Manager.numberOfCoins);
            Destroy(gameObject);
           
        }
    }
}
