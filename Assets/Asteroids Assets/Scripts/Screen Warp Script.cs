using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ScreenWarpScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint (transform.position);
        Vector2 newScreenPos = screenPos;

        if (screenPos.x < 0)
        {
            newScreenPos.x = Screen.width;
        }

        else if (screenPos.x > Screen.width)
        {
            newScreenPos.x = 0;
        }

        if (screenPos.y < 0)
        {
            newScreenPos.y = Screen.height;
        }

        else if (screenPos.y > Screen.height)
        {
            newScreenPos.y = 0;
        }

        if (newScreenPos != screenPos)
        {
            Vector2 newWorldPos = Camera.main.ScreenToWorldPoint (newScreenPos);
            transform.position = newWorldPos;
        }
    }
}
