using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] private Vector3 multiplier;

    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        Look();
    }

    private void Look()
    {
        transform.LookAt(player);

        RotationTools.Multiply(transform, multiplier);
    }
}