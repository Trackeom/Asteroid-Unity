using JetBrains.Annotations;
using UnityEngine;

public class MeteorScript : MonoBehaviour
{
    public float Collition_Damage = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        ShipScript Ship = collision.gameObject.GetComponent<ShipScript>();
        if (Ship != null)
        {
            Ship.Take_Damage(Collition_Damage);
        }
    }
}
