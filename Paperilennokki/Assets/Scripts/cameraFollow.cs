using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target; // The target object to follow
    public float smoothSpeed = 0.125f; // The smoothness of the camera follow
    public float distance = 5f; // The distance between the camera and the target
    public float height = 2f; // The height of the camera above the target

    void LateUpdate()
    {
        // Check if the target is null
        if (target == null)
        {
            Debug.LogWarning("CameraFollow: Target is not set.");
            return;
        }

        // Calculate the desired position of the camera
        Vector3 desiredPosition = target.position - target.forward * distance + Vector3.up * height;

        // Smoothly interpolate the current position of the camera towards the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Set the position of the camera to the smoothed position
        transform.position = smoothedPosition;

        // Look at the target
        transform.LookAt(target);
    }
}
