using UnityEngine;
using UnityEngine.UI;

public class RefillButtonScript : MonoBehaviour
{
    SerializeField Button;
    private ShipScript Ship;
     public void Click_Refill()
    {
        Ship = FindObjectOfType<ShipScript>();
        if (Ship != null && Ship.Pay > 100)
        {
            Ship.Fuel = Ship.Fuel + 75000;
            Ship.Pay = Ship.Pay - 100;
            Debug.Log("Working");
        }
    }
}
