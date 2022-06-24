using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField] private Vector3 multiplier;

    private Transform mainCamera;

    private void Start()
    {
        mainCamera = Camera.main.transform;
    }

    private void Update()
    {
        Look();
    }

    private void Look()
    {
        transform.LookAt(mainCamera);

        RotationTools.Multiply(transform, multiplier);
    }
}