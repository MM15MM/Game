using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            PlayerManager.numberOfCoins++;
            PlayerPrefs.SetInt("NumberOfCoins", PlayerManager.numberOfCoins);
            Destroy(gameObject);
        }
    }
}
