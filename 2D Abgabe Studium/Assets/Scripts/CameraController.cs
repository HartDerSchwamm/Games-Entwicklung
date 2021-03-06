using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 600f;
    public Vector3 offset;

    void LateUpdate()
    {
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }
}