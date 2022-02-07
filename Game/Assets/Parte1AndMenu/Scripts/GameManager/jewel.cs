using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jewel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            AudioManager.instance.Play("Collected");
            Destroy(gameObject);
            ScoreScript.instance.AddPoints();
        }
    }
}
