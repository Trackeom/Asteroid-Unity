using JetBrains.Annotations;
using UnityEngine;

public class FuelDropScript: MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D Collision)
    {
        if (Collision.gameObject.CompareTag("Player"))
        {
            ShipScript Ship = Collision.gameObject.GetComponent<ShipScript>();
       
            if (Ship != null)
            {
                Ship.Fuel += 10000;
            }

            Destroy(gameObject);
        }

    }
}

