using TMPro;
using UnityEngine;

public class LifeTimeHoursTrackerScript : MonoBehaviour
{
    public TMP_Text Time_Text_Box;
    public GameObject Time_Panel;

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
            Time_Text_Box.text = ":  " + Ship.Life_Time_Hours.ToString();
        }
    }
}