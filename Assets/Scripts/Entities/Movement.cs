using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float baseSpeed;

    [SerializeField, ReadOnly] private float speed;

    private Rigidbody myRigidbody;

    private void Awake()
    {
        speed = baseSpeed;

        myRigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction)
    {
        myRigidbody.velocity = direction * speed;
    }

    public void SetAddicionalSpeed(float extra)
    {
        speed = baseSpeed + extra;
    }
}