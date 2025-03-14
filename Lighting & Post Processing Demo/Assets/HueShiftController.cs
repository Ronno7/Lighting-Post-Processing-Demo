using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class HueShiftController : MonoBehaviour
{
    public PostProcessVolume volume;      // Assign your PostProcessVolume in the Inspector.
    public float hueShiftSpeed = 1.0f;      // Sensitivity for the mouse wheel input.

    private ColorGrading colorGrading;

    void Start()
    {
        // Try to fetch the ColorGrading settings from the volume's profile.
        if (volume != null && volume.profile.TryGetSettings(out colorGrading))
        {
            // ColorGrading successfully retrieved.
        }
        else
        {
            Debug.LogWarning("Color Grading is not found in the assigned volume profile.");
        }
    }

    void Update()
    {
        if (colorGrading != null)
        {
            // Get mouse wheel input.
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (Mathf.Abs(scroll) > 0.01f)
            {
                // Adjust hue shift based on scroll input.
                colorGrading.hueShift.value += scroll * hueShiftSpeed;
            }
        }
    }
}
