using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FasterBulletBarScript : MonoBehaviour
{
    public Slider FB_Slider;

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
            FB_Slider.value = Ship.Fast_Count_Down / Ship.Bigger_Firing_Rate;
        }
    }
}
