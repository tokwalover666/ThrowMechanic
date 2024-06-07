using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f); // Base offset for the camera
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;
    [SerializeField] private float verticalOffset = 2f; // Additional offset to adjust the vertical position

    private void Update()
    {
        Vector3 targetPosition = target.position + offset;

        // Adjust the y position with the vertical offset
        targetPosition.y += verticalOffset;

        // Preserve the original x position of the camera
        targetPosition.x = transform.position.x;

        // SmoothDamp only on the y and z positions
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        transform.position = new Vector3(transform.position.x, smoothPosition.y, smoothPosition.z);
    }
}
