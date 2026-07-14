using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click_To_Play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Click_To_Quit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
