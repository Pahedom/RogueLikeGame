using UnityEngine;

public class PiercingShots : PowerUp
{
    [SerializeField] private Gun gun;

    [SerializeField] private EnemyBounce enemyBounce;

    [SerializeField] private bool infinitePierce;

    private int maxPierces;

    private int[] pierces;

    private bool piercedThisFrame;

    private void Start()
    {
        foreach (Bullet bullet in gun.bullets)
        {
            bullet.OnHitEnemy += Pierce;

            bullet.poolObject.OnSpawn += ResetPierces;
        }

        pierces = new int[gun.bullets.Count];
    }

    private void LateUpdate()
    {
        piercedThisFrame = false;
    }

    private void Pierce(Bullet bullet, GameObject enemy)
    {
        if (!infinitePierce)
        {
            int index = gun.bullets.IndexOf(bullet);

            if (pierces[index] >= maxPierces)
            {
                if (!enemyBounce.CanBounce(bullet))
                {
                    bullet.poolObject.Dispawn();
                }

                return;
            }

            pierces[index]++;

            piercedThisFrame = true;
        }
    }

    private void ResetPierces(GameObject bullet)
    {
        pierces[gun.bullets.IndexOf(bullet.GetComponent<Bullet>())] = 0;
    }

    public bool CanPierce(Bullet bullet)
    {
        return pierces[gun.bullets.IndexOf(bullet)] < maxPierces || infinitePierce || piercedThisFrame;
    }

    public override void ApplyLevelEffects(int level)
    {
        maxPierces = level;
    }
}