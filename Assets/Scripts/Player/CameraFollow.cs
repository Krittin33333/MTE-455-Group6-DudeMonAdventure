using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The player character's transform.
    public float smoothSpeed = 0.125f; // Adjust this for camera follow speed.
    public Vector3 offset; // Offset position relative to the player.

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        desiredPosition.y = transform.position.y; // Keep the camera at the same vertical position.

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
