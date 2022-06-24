using UnityEngine;

public static class RotationTools
{
    public static void Multiply(Transform baseObject, Vector3 multiplier)
    {
        Vector3 currentRotation = baseObject.rotation.eulerAngles;

        Vector3 newRotation = new Vector3(currentRotation.x * multiplier.x, currentRotation.y * multiplier.y, currentRotation.z * multiplier.z);

        baseObject.rotation = Quaternion.Euler(newRotation);
    }

    public static Quaternion Multiply(Quaternion rotation, Vector3 multiplier)
    {
        Vector3 newRotation = new Vector3(rotation.x * multiplier.x, rotation.y * multiplier.y, rotation.z * multiplier.z);

        return Quaternion.Euler(newRotation);
    }
}