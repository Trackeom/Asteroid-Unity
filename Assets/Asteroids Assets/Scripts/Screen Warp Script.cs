using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ScreenWarpScript : MonoBehaviour
{
    private SpriteRenderer Sprite_Renderer;
    private bool has_Been_Visable = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Awake()
    {
        Sprite_Renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (has_Been_Visable == false && Sprite_Renderer.isVisible) //first time being visible
        {
            has_Been_Visable = true;
        }
        if (has_Been_Visable == false)
        {
            return; // don’t bother doing any more screen-wrapping if hasn’t been visible
        }

        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
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
            Vector2 newWorldPos = Camera.main.ScreenToWorldPoint(newScreenPos);
            transform.position = newWorldPos;
        }
    }
}

