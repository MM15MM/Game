using UnityEngine.SceneManagement;
using UnityEngine;
using Cinemachine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static int numberOfCoins;
    public TextMeshProUGUI CoinText;

    private void Awake()
    {
        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);

    }

    void Update()
    {
        CoinText.text = numberOfCoins.ToString();
       
    }

}