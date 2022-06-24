using UnityEngine;

public class HealthUpgrade : PowerUp
{
    [SerializeField] private Health health;

    [SerializeField] private float healthPerLevel;

    public override void ApplyLevelEffects(int level)
    {
        health.SetAddicionalHealth(level * healthPerLevel);
    }
}