using UnityEngine;

public class AttackSpeedUpgrade : PowerUp
{
    [SerializeField] private Gun gun;

    [SerializeField] private float attackSpeedPerLevel;

    public override void ApplyLevelEffects(int level)
    {
        gun.additionalAttackSpeed = level * attackSpeedPerLevel;

        gun.UpdateAttackSpeed();
    }
}