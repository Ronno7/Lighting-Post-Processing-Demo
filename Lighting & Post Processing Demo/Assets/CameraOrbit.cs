using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public float manualRotationSpeed = 100f;   // Speed for manual rotation
    public float autoRotationSpeed = 20f;      // Speed for auto rotation
    public float inactivityDelay = 5f;         // Seconds to wait before auto rotating

    private float lastInputTime;               // Time since last manual input
    private int autoDirection = 1;             // Last input direction (1 for right, -1 for left)

    void Start()
    {
        lastInputTime = Time.time;             // Initialize the last input time
    }

    void Update()
    {
        // Get horizontal input from the user (left/right arrow or A/D keys)
        float horizontalInput = Input.GetAxis("Horizontal");

        if (Mathf.Abs(horizontalInput) > 0.1f)
        {
            // Rotate the camera manually around the world origin on the Y-axis
            transform.RotateAround(Vector3.zero, Vector3.up, horizontalInput * manualRotationSpeed * Time.deltaTime);

            // Update the time of the last manual input
            lastInputTime = Time.time;

            // Update autoDirection based on the current input
            autoDirection = (horizontalInput > 0) ? 1 : -1;
        }
        else if (Time.time - lastInputTime > inactivityDelay)
        {
            // Automatically rotate the camera after inactivity using the last input direction
            transform.RotateAround(Vector3.zero, Vector3.up, autoDirection * autoRotationSpeed * Time.deltaTime);
        }
    }
}
