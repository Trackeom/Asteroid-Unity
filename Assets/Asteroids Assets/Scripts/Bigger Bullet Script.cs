using UnityEngine;

public class BiggerBulletScript : MonoBehaviour
{
    public float Collition_Damage = 1f;
    public GameObject Explosion_Ref;
    public float Max_HP = 3f;
    public float Current_HP;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Current_HP = Max_HP;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Take_Damage(float damage)
    {
        Current_HP = Current_HP - damage;
        Instantiate (Explosion_Ref, transform.position, transform.rotation);

        if (Current_HP <= 0f)
        {
            Explode();
        }
    }

    public void OnTriggerEnter2D(Collider2D trigger)
    {
        // When Bullet Touches Meteor find Meteor
        MeteorScript Meteor = trigger.gameObject.GetComponent<MeteorScript>();

        // If Meteor is found call (Take_Damage or Explode)
        if (Meteor != null)
        {
            Meteor.Take_Damage(Collition_Damage);
            Take_Damage(Meteor.Collision_Damage);
        }
        // When Bullet Touches OMeteor find OMeteor
        ObsidianMeteorScript OMeteor = trigger.gameObject.GetComponent<ObsidianMeteorScript>();

        // If Meteor is found call (Take_Damage or Explode)
        if (OMeteor != null)
        {
            OMeteor.Take_Damage(Collition_Damage);
            Explode();
        }
        // When Bullet Touches AlienTurret find AlienTurret
        AlienTurretScript AlienTurret = trigger.gameObject.GetComponent<AlienTurretScript>();

        // If Meteor is found call (Take_Damage or Explode)
        if (AlienTurret != null)
        {
            AlienTurret.Take_Damage(Collition_Damage);
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
