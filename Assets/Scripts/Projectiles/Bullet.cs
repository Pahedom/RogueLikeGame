using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    public float speed;

    public PoolObject poolObject;

    public UnityAction<Bullet, Transform> OnHitWall;

    public UnityAction<Bullet, GameObject> OnHitEnemy;

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            OnHitWall?.Invoke(this, other.transform);

            return;
        }

        if (other.CompareTag("Enemy"))
        {
            OnHitEnemy?.Invoke(this, other.gameObject);

            return;
        }
    }
}