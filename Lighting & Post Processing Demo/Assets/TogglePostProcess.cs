using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TogglePostProcess : MonoBehaviour
{
    // Set the key to toggle the post-process volume in the Inspector.
    [SerializeField] private KeyCode toggleKey = KeyCode.P;

    private PostProcessVolume postProcessVolume;

    void Start()
    {
        // Get the PostProcessVolume component attached to the same GameObject.
        postProcessVolume = GetComponent<PostProcessVolume>();

        // Warn if the component is not found.
        if (postProcessVolume == null)
        {
            Debug.LogWarning("No PostProcessVolume component found on this GameObject.");
        }
    }

    void Update()
    {
        // Check if the toggle key is pressed and the component exists.
        if (Input.GetKeyDown(toggleKey) && postProcessVolume != null)
        {
            // Toggle the enabled state of the post-process volume.
            postProcessVolume.enabled = !postProcessVolume.enabled;
            Debug.Log("PostProcessVolume is now " + (postProcessVolume.enabled ? "enabled" : "disabled"));
        }
    }
}
