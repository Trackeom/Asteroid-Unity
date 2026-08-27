using JetBrains.Annotations;
using UnityEngine;

public class ObsidianMeteorScript : MonoBehaviour
{
    public int Spawn_Value = 5;
    public float Max_HP = 1f;
    public float Current_HP;
    public float Collision_Damage = 1f;
    public GameObject Explosion_Ref1;
    public GameObject Explosion_Ref2;
    public GameObject Meteor_Origonal_Ref;
    public GameObject Bigger_Power_Up_Ref;
    public GameObject Fuel_Drop_Ref;
    public float Explosion_Dist = 0.5f;
    public float Explosion_Force = 10f;
    public int Score_Value = 10;

    void Start()
    {
        Current_HP += Max_HP;

        ShipScript Ship = FindObjectOfType<ShipScript>();
        if (Ship != null)
        {
            Ship.Enemy_Counter += 1;
        }
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
        ShipScript Ship = FindObjectOfType<ShipScript>();
        if (Ship != null)
        {
            Ship.IncreaseScore(Score_Value);
            Ship.Enemy_Counter -= 1;
        }

        Spawn_Meteor_Origonal();
        Instantiate(Explosion_Ref1, transform.position, transform.rotation);
        Instantiate(Explosion_Ref2, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void Spawn_Meteor_Origonal()
    {
        Instantiate(Meteor_Origonal_Ref, transform.position, transform.rotation);

        if (Random.Range(0, 10) == 5)
        {
            Instantiate(Bigger_Power_Up_Ref, transform.position, transform.rotation);
        }
    }
}