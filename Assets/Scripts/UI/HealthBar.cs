using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health health;

    [SerializeField] private Slider healthSlider;

    [SerializeField] private TextMeshProUGUI healthText;

    void Start()
    {
        health.OnTakeDamage += UpdateDisplay;

        health.OnHealthUpgrade += UpdateDisplay;

        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        healthSlider.maxValue = health.maxHealth;

        healthSlider.value = health.currentHealth;

        if (healthText)
        {
            healthText.text = health.currentHealth + "/" + health.maxHealth;
        }
    }
}