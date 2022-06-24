using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class Gun : MonoBehaviour
{
    [SerializeField] private float baseDamage;

    [SerializeField] private float baseAttackSpeed;

    [SerializeField] private GameObject[] barrels;

    [SerializeField] private Pool bulletPool;

    [ReadOnly] public float additionalDamage;

    [ReadOnly] public float additionalAttackSpeed;

    [SerializeField, ReadOnly] private float currentDamage;

    [SerializeField, ReadOnly] private float currentAttackSpeed;

    public UnityEvent OnShoot;

    public UnityAction<Health> OnDealDamage;

    internal List<Bullet> bullets;

    private float timer;

    private void OnValidate()
    {
        UpdateDamage();

        UpdateAttackSpeed();
    }

    private void Start()
    {
        currentDamage = baseDamage;

        currentAttackSpeed = baseAttackSpeed;

        bullets = new List<Bullet>();

        for (int i = 0; i < bulletPool.numberOfClones; i++)
        {
            bullets.Add(bulletPool.clones[i].GetComponent<Bullet>());

            bullets[i].OnHitEnemy += DealDamage;
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }

    public bool TryShoot()
    {
        if (timer >= 1 / currentAttackSpeed)
        {
            Shoot();

            timer = 0;

            return true;
        }

        return false;
    }

    public void Shoot()
    {
        for (int i = 0; i < barrels.Length; i++)
        {
            if (barrels[i].activeSelf)
            {
                bulletPool.Spawn(barrels[i].transform.position, barrels[i].transform.rotation);
            }
        }

        OnShoot?.Invoke();
    }

    public void DealDamage(Bullet bullet, GameObject target)
    {
        Health targetHealth = target.GetComponent<Health>();

        targetHealth.TakeDamage(currentDamage);

        OnDealDamage?.Invoke(targetHealth);
    }

    public void UpdateDamage()
    {
        currentDamage = baseDamage + additionalDamage;
    }

    public void UpdateAttackSpeed()
    {
        currentAttackSpeed = baseAttackSpeed + additionalAttackSpeed;
    }

    public void ActivateFrontBarrels(int numberOfBarrels)
    {
        barrels[0].SetActive(numberOfBarrels % 2 != 0 && numberOfBarrels != 0);

        barrels[1].SetActive(numberOfBarrels > 1);

        barrels[2].SetActive(numberOfBarrels > 1);
    }
}