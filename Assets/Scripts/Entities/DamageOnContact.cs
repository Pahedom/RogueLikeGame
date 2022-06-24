using UnityEngine;

public class DamageOnContact : MonoBehaviour
{
    [SerializeField] private string targetTag;

    [SerializeField] private float damage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }
}