using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health PlayerHealth;
    [SerializeField] private Image HealthBarTotale;
    [SerializeField] private Image CurrentHealthBar;
    private void Start()
    {
        HealthBarTotale.fillAmount = PlayerHealth.CurrentHealth / 10;
    }

   private void Update()
    {
        CurrentHealthBar.fillAmount = PlayerHealth.CurrentHealth / 10;
    }
}
