using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeButtonScript : MonoBehaviour
{
    SerializeField Button;
    public VisableUpgradesScript Upgrade_Panal;
    public bool Selected = false;

    private ShipScript Ship;

    public void Update()
    {
        if (Selected == true)
        {
            Upgrade_Panal.Invisable();
            Ship.Leveling_Up = false;
            Selected = false;
            Debug.Log("Turn Invis");
        }
    }

    public void Click_Movement()
    {
        Ship = FindObjectOfType<ShipScript>();
        if (Ship != null && Ship.Pay > 250)
        {
            if (Ship.Leveling_Up = true)
            {
                Ship.Engine_Power = Ship.Engine_Power + 10;
                Ship.Pay = Ship.Pay - 250;
                Selected = true;
            }
        }
    }

    public void Click_Bullet()
    {
        Ship = FindObjectOfType<ShipScript>();
        if (Ship != null && Ship.Pay > 500)
        {
            if (Ship.Leveling_Up = true)
            {
                Ship.Bullet_Speed = Ship.Bullet_Speed + 20;
                Ship.Pay = Ship.Pay - 500;
                Selected = true;
            }
        }
    }

    public void Click_Life()
    {
        Ship = FindObjectOfType<ShipScript>();
        if (Ship != null && Ship.Pay > 750)
        {
            if (Ship.Leveling_Up = true)
            {
                Ship.Max_HP = Ship.Max_HP + 1;
                Ship.Current_HP = Ship.Current_HP + 1;
                Ship.Pay = Ship.Pay - 750;
                Selected = true;
            }
        }
    }
}