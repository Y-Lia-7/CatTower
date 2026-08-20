using UnityEngine;

public class CameraFollowOnY : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    void FixedUpdate()
    {
        if (target == null)
            return;

        Vector3 targetPos = target.position;

        transform.position = new Vector3(
            transform.position.x,
            Mathf.Min(transform.position.y, targetPos.y + offset.y),
            transform.position.z
        );
    }
}
