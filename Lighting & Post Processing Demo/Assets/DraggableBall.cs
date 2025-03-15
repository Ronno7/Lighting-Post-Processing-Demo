using UnityEngine;

public class DraggableBall : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f; // Speed at which the ball moves to the drag point

    private Rigidbody rb;
    private Plane groundPlane;
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 targetPosition;

    void Start()
    {
        // Get the Rigidbody component.
        rb = GetComponent<Rigidbody>();

        // Create a plane with an upward-facing normal at y = 0.
        // Adjust if your floor is at a different height.
        groundPlane = new Plane(Vector3.up, Vector3.zero);
    }

    void OnMouseDown()
    {
        isDragging = true;

        // Cast a ray from the camera to the mouse position.
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float enter;

        // If the ray hits the ground plane, record the offset from the ball.
        if (groundPlane.Raycast(ray, out enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);
            offset = transform.position - hitPoint;
        }
    }

    void OnMouseDrag()
    {
        // Update the target position based on the new mouse position.
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float enter;

        if (groundPlane.Raycast(ray, out enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);
            targetPosition = hitPoint + offset;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void FixedUpdate()
    {
        // Smoothly move the ball toward the target position using physics.
        if (isDragging)
        {
            Vector3 newPosition = Vector3.MoveTowards(rb.position, targetPosition, moveSpeed * Time.fixedDeltaTime);
            rb.MovePosition(newPosition);
        }
    }
}
