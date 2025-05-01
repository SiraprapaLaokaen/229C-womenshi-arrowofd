using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target; // ตัวละครที่จะตาม
    public float smoothSpeed = 0.125f; // ความลื่นของการตาม
    public Vector3 offset; // ระยะห่างของกล้องกับเป้าหมาย

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
    }
}
