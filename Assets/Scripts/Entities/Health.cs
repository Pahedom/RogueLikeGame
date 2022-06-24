using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float baseMaxHealth;

    [ReadOnly] public float maxHealth;

    [ReadOnly] public float currentHealth;

    internal bool isDead;

    public UnityAction OnTakeDamage;

    public UnityAction<Health> OnDie;

    public UnityAction OnHealthUpgrade;

    void Awake()
    {
        maxHealth = baseMaxHealth;

        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        OnTakeDamage?.Invoke();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        isDead = true;

        OnDie?.Invoke(this);

        gameObject.SetActive(false);
    }

    public void SetAddicionalHealth(float extra)
    {
        maxHealth = baseMaxHealth + extra;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        OnHealthUpgrade?.Invoke();
    }
}