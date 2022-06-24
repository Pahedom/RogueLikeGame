using UnityEngine;

public class RepeatedShots : PowerUp
{
    [SerializeField] private Gun gun;

    [SerializeField] private float repeatDelay;

    private int repeatedShots;

    private int repeats;

    private float timer;

    private void Start()
    {
        gun.OnShoot.AddListener(RepeatShot);
    }

    private void Update()
    {
        if (repeats == 0)
        {
            return;
        }

        timer += Time.deltaTime;

        if (timer >= repeatDelay)
        {
            gun.Shoot();
        }
    }

    private void RepeatShot()
    {
        if (repeats < repeatedShots)
        {
            repeats++;

            timer = 0;
        }
        else
        {
            repeats = 0;
        }
    }

    public override void ApplyLevelEffects(int level)
    {
        repeatedShots = level;
    }
}