using JetBrains.Annotations;
using UnityEngine;

public class MeteorScript : MonoBehaviour
{
    public float Max_HP = 3f;
    public float Current_HP;
    public float Collision_Damage = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D Collision)
    {
        ShipScript Ship = Collision.gameObject.GetComponent<ShipScript>();
        if (Ship != null)
        {
            Ship.Take_Damage(Collision_Damage);
        }
    }


    public void Take_Damage(float damage)
    {
        Current_HP = Current_HP - damage;

        if (Current_HP <= 0f)
        {
            Explode();
        }
    }

        public void Explode()
        {
            Destroy(gameObject);
        }
}

