using UnityEngine;

public class BulletScript : MonoBehaviour
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

    public void OnTriggerEnter2D(Collider2D trigger)
    {
        MeteorScript Meteor = trigger.gameObject.GetComponent<MeteorScript>();
        if (Meteor != null)
        {
            Meteor.Take_Damage(Collition_Damage);
            Explode();
        }
    }

    

    public void Explode()
    {
        Destroy(gameObject);
    }
}
