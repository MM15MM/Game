using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainingHealth : MonoBehaviour
{
    [SerializeField] private float HealthValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().AddHealth(HealthValue);
            gameObject.SetActive(false);
            AudioManager.instance.Play("HeartCollected");
        }
    }
}
