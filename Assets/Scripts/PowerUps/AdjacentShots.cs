using UnityEngine;

public class AdjacentShots : PowerUp
{
    [SerializeField] private Gun gun;

    public override void ApplyLevelEffects(int level)
    {
        gun.ActivateFrontBarrels(level + 1);
    }
}