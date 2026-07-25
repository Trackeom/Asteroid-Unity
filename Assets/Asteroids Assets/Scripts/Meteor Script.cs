using JetBrains.Annotations;
using UnityEngine;

public class MeteorScript : MonoBehaviour
{
    public int Spawn_Value = 3;
    public float Max_HP = 3f;
    public float Current_HP;
    public float Collision_Damage = 1f;
    public GameObject Explosion_Ref;
    public GameObject[] Meteor_Chunks;
    public int Min_Chunks = 2;
    public int Max_Chunks = 3;
    public float Explosion_Dist = 0.5f;
    public float Explosion_Force = 10f;
    public int Score_Value = 10;

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
        ShipScript ship = FindObjectOfType<ShipScript>();
        if (ship != null)
        {
            ship.Score += Score_Value;
        }
        if (Meteor_Chunks.Length > 0)
        {
            int Meteor_Chunks = Random.Range(Min_Chunks, Max_Chunks);

            for (int i = 0; i < Meteor_Chunks; i++)
            {
                Create_Meteor_Chunk();
            }
            
        }

        Instantiate(Explosion_Ref, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void Create_Meteor_Chunk()
    {
        int randomIndex = Random.Range (0, Meteor_Chunks.Length);
        GameObject Meteor_Chunk_To_Copy = Meteor_Chunks[randomIndex];

        Vector3 spawnPos = transform.position;
        spawnPos.x += Random.Range(-Explosion_Dist, Explosion_Dist);
        spawnPos.y += Random.Range(-Explosion_Dist, Explosion_Dist);

        GameObject Meteor_Chunk = Instantiate(Meteor_Chunk_To_Copy, spawnPos, transform.rotation);

        Vector3 dir = (spawnPos - transform.position).normalized;

        Rigidbody2D rb = Meteor_Chunk.GetComponent<Rigidbody2D>();
        rb.AddForce (dir * Explosion_Force);
    }
}

