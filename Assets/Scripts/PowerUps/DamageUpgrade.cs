using UnityEngine;

public class DamageUpgrade : PowerUp
{
    [SerializeField] private Gun gun;

    [SerializeField] private float damagePerLevel;

    public override void ApplyLevelEffects(int level)
    {
        gun.additionalDamage = level * damagePerLevel;

        gun.UpdateDamage();
    }
}