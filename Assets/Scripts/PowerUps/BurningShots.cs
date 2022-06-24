using System.Collections.Generic;
using UnityEngine;

public class BurningShots : PowerUp
{
    [SerializeField] private Gun gun;

    [SerializeField] private float burningTime;

    [SerializeField] private float damagePerLevel;

    [SerializeField, ReadOnly] private float damagePerSec;

    private List<Health> burningTargets;

    private List<float> timers;

    private void Start()
    {
        burningTargets = new List<Health>();

        timers = new List<float>();

        gun.OnDealDamage += ApplyBurning;
    }

    int previousTime;
    private void Update()
    {
        for (int i = 0; i < burningTargets.Count; i++)
        {
            previousTime = (int)timers[i];

            timers[i] += Time.deltaTime;

            if ((int)timers[i] > previousTime)
            {
                burningTargets[i].TakeDamage(damagePerSec);

                if (burningTargets[i].isDead)
                {
                    RemoveBurning(burningTargets[i]);

                    i--;

                    continue;
                }
            }

            if (timers[i] >= burningTime)
            {
                RemoveBurning(burningTargets[i]);
            }
        }
    }

    private void ApplyBurning(Health target)
    {
        if (burningTime <= 0 || damagePerSec <= 0)
        {
            return;
        }

        if (burningTargets.Contains(target))
        {
            int index = burningTargets.IndexOf(target);

            timers[index] -= (int)timers[index];
        }
        else
        {
            burningTargets.Add(target);

            timers.Add(0);
        }
    }

    private void RemoveBurning(Health target)
    {
        timers.RemoveAt(burningTargets.IndexOf(target));

        burningTargets.Remove(target);
    }

    public override void ApplyLevelEffects(int level)
    {
        damagePerSec = level * damagePerLevel;
    }
}