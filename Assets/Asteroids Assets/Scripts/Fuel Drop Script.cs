using JetBrains.Annotations;
using UnityEngine;

public class FuelDropScript: MonoBehaviour
{
    public GameObject Explosion_Ref1;
    public GameObject Explosion_Ref2;

    public void OnCollisionEnter2D(Collision2D Collision)
    {
        if (Collision.gameObject.CompareTag("Player"))
        {
            ShipScript Ship = Collision.gameObject.GetComponent<ShipScript>();
       
            if (Ship != null)
            {
                Ship.Fuel += 10000;
            }

            Instantiate(Explosion_Ref1, transform.position, transform.rotation);
            Instantiate(Explosion_Ref2, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }
}

