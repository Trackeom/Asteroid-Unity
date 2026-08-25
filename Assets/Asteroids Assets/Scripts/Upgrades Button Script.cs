using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtonScript : MonoBehaviour
{
    SerializeField Button;
    private Image Upgrade_Board;
    private ShipScript Ship;
    public void Click_Movement()
    {
        Ship = FindObjectOfType<ShipScript>();
        if (Ship != null && Ship.Pay > 250)
        {
            Ship.Fuel = Ship.Fuel + 75000;
            Ship.Pay = Ship.Pay - 250;
            Close_Board();
        }
    }

    public void Click_Bullet()
    {
        Ship = FindObjectOfType<ShipScript>();
        if (Ship != null && Ship.Pay > 250)
        {
            Ship.Bullet_Speed = Ship.Bullet_Speed + 10;
            Ship.Pay = Ship.Pay - 250;
            Close_Board();
        }
    }

    public void Click_Life()
    {
        Ship = FindObjectOfType<ShipScript>();
        if (Ship != null && Ship.Pay > 500)
        {
            Ship.Max_HP = Ship.Max_HP + 1;
            Ship.Current_HP = Ship.Current_HP + 1;
            Ship.Pay = Ship.Pay - 500;
            Close_Board();
        }
    }

    public void Close_Board()
    {

    }
}