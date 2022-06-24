using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    [SerializeField] private Transform baseObject;

    private Camera mainCamera;

    private Plane plane;

    private Ray ray;

    private float distance;

    private void Start()
    {
        mainCamera = Camera.main;

        plane = new Plane(Vector3.up, Vector3.up * baseObject.position.y);
    }

    private void Update()
    {
        Look();
    }

    private void Look()
    {
        ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (!plane.Raycast(ray, out distance))
        {
            return;
        }

        transform.LookAt(ray.GetPoint(distance));

        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
}