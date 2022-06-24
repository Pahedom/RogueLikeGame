using UnityEngine;

public class WallBounce : PowerUp
{
    [SerializeField] private Gun gun;

    [SerializeField] private bool infiniteBounce;

    private int maxBounces;

    private int[] bounces;

    private void Start()
    {
        foreach (Bullet bullet in gun.bullets)
        {
            bullet.OnHitWall += Bounce;

            bullet.poolObject.OnSpawn += ResetBounces;
        }

        bounces = new int[gun.bullets.Count];
    }

    private void Bounce(Bullet bullet, Transform wallTransform)
    {
        if (!infiniteBounce)
        {
            int index = gun.bullets.IndexOf(bullet);

            if (bounces[index] >= maxBounces)
            {
                bullet.poolObject.Dispawn();

                return;
            }

            bounces[index]++;
        }

        Vector3 newDirection = Vector3.Reflect(bullet.transform.forward, wallTransform.forward);

        bullet.transform.rotation = Quaternion.LookRotation(newDirection);
    }

    private void ResetBounces(GameObject bullet)
    {
        bounces[gun.bullets.IndexOf(bullet.GetComponent<Bullet>())] = 0;
    }

    public override void ApplyLevelEffects(int level)
    {
        maxBounces = level;
    }
}