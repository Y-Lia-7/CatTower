using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 5f;

    private void FixedUpdate()
    {
        if (target == null)
        {
            return;
        }
        Vector3 desiredPosition = target.position;
        desiredPosition.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    }
}