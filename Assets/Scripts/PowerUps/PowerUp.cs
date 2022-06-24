using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    [Min(0)]
    public int level;

    [Min(0)]
    public int maxLevel;

    private void OnValidate()
    {
        if (level > maxLevel)
        {
            level = maxLevel;
        }

        ApplyLevelEffects(level);
    }

    public void Upgrade()
    {
        if (level + 1 > maxLevel)
        {
            Debug.LogError("Already max level");

            return;
        }

        level++;

        ApplyLevelEffects(level);
    }

    public void Downgrade()
    {
        if (level - 1 < 0)
        {
            Debug.LogError("Already min level");

            return;
        }

        level--;

        ApplyLevelEffects(level);
    }

    public void SetLevel(int newLevel)
    {
        if (newLevel < 0 || newLevel > maxLevel)
        {
            Debug.LogError("Invalid level");

            return;
        }

        level = newLevel;

        ApplyLevelEffects(level);
    }

    public abstract void ApplyLevelEffects(int level);
}