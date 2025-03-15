using UnityEngine;
using UnityEngine.SceneManagement;

public class ToggleScenes : MonoBehaviour
{
    // Call this method to swap between the two scenes.
    public void ToggleScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = (currentIndex == 0) ? 1 : 0;
        SceneManager.LoadScene(nextIndex);
    }
}
