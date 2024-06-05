using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player transform
    public Vector3 offset;   // Offset between the player and camera

    private void Start()
    {
        // Initialize the offset based on the initial positions of the camera and player
        offset = transform.position - player.position;
    }

    private void LateUpdate()
    {
        // Calculate the desired position of the camera
        Vector3 desiredPosition = player.position + offset;

        // Maintain the original Y rotation of the camera
        Quaternion currentRotation = transform.rotation;

        // Set the camera position
        transform.position = desiredPosition;

        // Restore the original Y rotation of the camera
        transform.rotation = Quaternion.Euler(currentRotation.eulerAngles.x, currentRotation.eulerAngles.y, currentRotation.eulerAngles.z);
    }
}
