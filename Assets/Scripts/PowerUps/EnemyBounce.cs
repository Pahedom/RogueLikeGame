using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyBounce : PowerUp
{
    [SerializeField] private Gun gun;

    [SerializeField] private PiercingShots pierce;

    [SerializeField] bool infiniteBounce;

    [SerializeField] bool ignoreMaxDistance;

    [SerializeField] private float maxDistance;

    private int maxBounces;

    private int[] bounces;

    private bool bouncedThisFrame;

    private void Start()
    {
        foreach (Bullet bullet in gun.bullets)
        {
            bullet.OnHitEnemy += Bounce;

            bullet.poolObject.OnSpawn += ResetBounces;
        }

        bounces = new int[gun.bullets.Count];
    }

    private void LateUpdate()
    {
        bouncedThisFrame = false;
    }

    private void Bounce(Bullet bullet, GameObject enemy)
    {
        int index = gun.bullets.IndexOf(bullet);

        bool canPierce = pierce.CanPierce(bullet);

        if (!infiniteBounce)
        {
            if (bounces[index] >= maxBounces)
            {
                if (!canPierce)
                {
                    bullet.poolObject.Dispawn();
                }

                return;
            }
        }

        List<GameObject> enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList();

        enemies.Remove(enemy);

        if (enemies.Count == 0)
        {
            if (!canPierce)
            {
                bullet.poolObject.Dispawn();
            }

            return;
        }

        Transform nearestEnemy = enemies[0].transform;

        float nearestDistance = Vector3.Distance(bullet.transform.position, nearestEnemy.position);

        float distance;

        for (int i = 1; i < enemies.Count; i++)
        {
            distance = Vector3.Distance(bullet.transform.position, enemies[i].transform.position);

            if (distance < nearestDistance)
            {
                nearestEnemy = enemies[i].transform;

                nearestDistance = distance;
            }
        }

        if (!ignoreMaxDistance)
        {
            if (nearestDistance > maxDistance)
            {
                if (!canPierce)
                {
                    bullet.poolObject.Dispawn();
                }

                return;
            }
        }

        bullet.transform.LookAt(nearestEnemy);

        bullet.transform.rotation = Quaternion.Euler(0, bullet.transform.rotation.eulerAngles.y, 0);

        bounces[index]++;

        bouncedThisFrame = true;
    }

    private void ResetBounces(GameObject bullet)
    {
        bounces[gun.bullets.IndexOf(bullet.GetComponent<Bullet>())] = 0;
    }

    public bool CanBounce(Bullet bullet)
    {
        return bounces[gun.bullets.IndexOf(bullet)] < maxBounces || infiniteBounce || bouncedThisFrame;
    }

    public override void ApplyLevelEffects(int level)
    {
        maxBounces = level;
    }
}