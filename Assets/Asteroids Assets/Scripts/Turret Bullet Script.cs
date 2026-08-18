using UnityEngine;

public class TurretBulletScript : MonoBehaviour
{
    public float Collition_Damage = 1f;
    public GameObject Explosion_Ref;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D trigger)
    {
        // When Bullet Touches Meteor find Meteor
        MeteorScript Meteor = trigger.gameObject.GetComponent<MeteorScript>();

        // If Meteor is found call (Take_Damage or Explode)
        if (Meteor != null)
        {
            Meteor.Take_Damage(Collition_Damage);
            Explode();
        }
        // When Bullet Touches Meteor find Meteor
        ObsidianMeteorScript OMeteor = trigger.gameObject.GetComponent<ObsidianMeteorScript>();

        // If Meteor is found call (Take_Damage or Explode)
        if (OMeteor != null)
        {
            OMeteor.Take_Damage(Collition_Damage);
            Explode();
        }
        // When Bullet Touches Meteor find Meteor
        ShipScript Ship = trigger.gameObject.GetComponent<ShipScript>();

        // If Meteor is found call (Take_Damage or Explode)
        if (Ship != null)
        {
            Ship.Take_Damage(Collition_Damage);
            Explode();
        }
    }

    // Triggers when called
    public void Explode()
    {
        // Spawn (Explotion_Ref) at Meteor location then destroy itself
        Instantiate(Explosion_Ref, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
