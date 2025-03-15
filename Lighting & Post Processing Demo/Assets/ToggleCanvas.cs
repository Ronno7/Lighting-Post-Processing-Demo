using UnityEngine;

public class ToggleCanvas : MonoBehaviour
{
    // Set the key to toggle the canvas in the Inspector.
    [SerializeField] private KeyCode toggleKey = KeyCode.C;

    private Canvas canvas;

    void Start()
    {
        // Retrieve the Canvas component attached to this GameObject.
        canvas = GetComponent<Canvas>();
        if (canvas == null)
        {
            Debug.LogWarning("No Canvas component found on this GameObject.");
        }
    }

    void Update()
    {
        // Check for the key press and toggle the canvas if it exists.
        if (Input.GetKeyDown(toggleKey) && canvas != null)
        {
            canvas.enabled = !canvas.enabled;
            Debug.Log("Canvas is now " + (canvas.enabled ? "enabled" : "disabled"));
        }
    }
}
