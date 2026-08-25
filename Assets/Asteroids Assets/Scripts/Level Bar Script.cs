using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelBarScript : MonoBehaviour
{
    public Slider Level_Slider;

    private ShipScript Ship;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Ship = FindObjectOfType<ShipScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Ship != null)
        {
            Level_Slider.value = Ship.Start_Level;
            Level_Slider.maxValue = Ship.Max_Level;
        }
    }
}
