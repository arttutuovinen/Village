using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    
    public float acceleration = 1000f;
    public float turnSpeed = 300f;
    public float maxSpeed = 20f;
    public float movementThreshold = 0.1f; // Threshold to check if the car is moving

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -0.9f, 0); // Lower the center of mass to prevent tipping
    }

    void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Vertical"); // W/S or Up/Down arrow keys
        float turnInput = Input.GetAxis("Horizontal"); // A/D or Left/Right arrow keys

        // Forward and backward movement
        if (moveInput != 0)
        {
            Vector3 force = transform.forward * moveInput * acceleration * Time.deltaTime;
            rb.AddForce(force, ForceMode.Acceleration);
        }
        if (rb.velocity.magnitude > movementThreshold)
        {
            // Left and right turning
            if (turnInput != 0)
            {
                float turn = turnInput * turnSpeed * Time.deltaTime;
                Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
                rb.MoveRotation(rb.rotation * turnRotation);
            }
        }

        // Cap the car's speed
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}
    

