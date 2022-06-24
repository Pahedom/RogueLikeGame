using UnityEngine;

public class SpeedUpgrade : PowerUp
{
    [SerializeField] private Movement movement;

    [SerializeField] private float speedPerLevel;

    public override void ApplyLevelEffects(int level)
    {
        movement.SetAddicionalSpeed(level * speedPerLevel);
    }
}