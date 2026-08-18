using System.Collections;
using UnityEngine;

public class AlienTurretScript : MonoBehaviour
{
    public int Spawn_Value = 7;
    public float Fire_Timer = 0f;
    public GameObject Bullet_Ref;
    public float Bullet_Speed;
    public float Collision_Damage = 1f;
    public float Max_HP = 3f;
    public float Current_HP;
    public GameObject Explosion_Ref;
    public int Score_Value = 75;
    ShipScript Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Current_HP = Max_HP;
        Player = FindObjectOfType<ShipScript>();

        StartCoroutine(MoveMe());
    }

    IEnumerator MoveMe()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            for (int x = 0; x < 100; x++)
            {
                if (Player != null)
                {
                    transform.position = Vector3.Lerp(transform.position, Player.transform.position, Time.deltaTime);
                }
                yield return new WaitForEndOfFrame();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            Fire_Timer += Time.deltaTime;
            Vector3 direction = Player.transform.position - transform.position;
            transform.up = direction;
            
            if (Fire_Timer > 2)
            {
                Fire_Timer = 0;
                Fire_Bullet();
            }
        }
    }
    public void Fire_Bullet()
    {
        GameObject Bullet = Instantiate(Bullet_Ref, transform.position, transform.rotation);
        Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
        Vector2 Force = transform.up * Bullet_Speed;
        rb.AddForce(Force);
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
            ship.IncreaseScore(Score_Value);
        }
        Instantiate(Explosion_Ref, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
