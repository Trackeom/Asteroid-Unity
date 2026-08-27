using JetBrains.Annotations;
using UnityEngine;

public class FuelDropScript: MonoBehaviour
{
    public float Max_HP = 3f;
    public float Current_HP;
    public float Collision_Damage = 1f;

    public void OnCollisionEnter2D(Collision2D Collision)
    {
        ShipScript Ship = Collision.gameObject.GetComponent<ShipScript>();
       
        if (Ship != null)
        {
            Ship.Fuel += 10000;
        }

        Destroy(gameObject);
    }
}

