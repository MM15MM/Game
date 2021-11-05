using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static int numberOfCoins;
    public TextMeshProUGUI coinsText;

 
    void Update()
    {
        coinsText.text = numberOfCoins.ToString();
        
    }
}
