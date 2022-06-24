using UnityEngine;
using UnityEngine.Events;

public class PoolObject : MonoBehaviour
{
    public Pool pool;

    public UnityAction<GameObject> OnSpawn;

    public void Dispawn()
    {
        pool.Dispawn(gameObject);
    }
}