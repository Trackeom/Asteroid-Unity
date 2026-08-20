using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BiggerBulletBarScript : MonoBehaviour
{
    public Slider BB_Slider;

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
            BB_Slider.value = Ship.Big_Count_Down / Ship.Bigger_Firing_Rate;
        }
    }
}
