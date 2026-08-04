using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Called when UI Button Back is pressed
    public void Click_To_Play()
    {
        // Load level (Play)
        SceneManager.LoadScene("Play");
    }

    // Called when UI Button Back is pressed
    public void Click_To_Quit()
    {
        // Set Play mode to Pause
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
