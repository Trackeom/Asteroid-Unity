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
    public GameObject Faster_Power_Up_Ref;
    public int Score_Value = 75;
    public float Timer = 0f;
    public bool Moving;
    ShipScript Player;
    public SpriteRenderer mySpriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Timer = Time.deltaTime;
        Current_HP = Max_HP;
        Player = FindObjectOfType<ShipScript>();

        StartCoroutine (Move_To_Target());
    }

    IEnumerator Move_To_Target()
    {
        while (mySpriteRenderer.isVisible == false)
        {
            if (Player != null)
            {
                transform.position = Vector3.Lerp(transform.position, Player.transform.position, Time.deltaTime);
            }
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(1); //wait onscreen and look at the player before moving

        float deltaTime = 0;
        while(deltaTime < 0.5) //how many seconds to move towards the player
        {
            deltaTime += Time.deltaTime;
            if (Player != null)
            {
                transform.position = Vector3.Lerp(transform.position, Player.transform.position, Time.deltaTime);
            }
            yield return new WaitForEndOfFrame();
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
        Instantiate(Explosion_Ref, transform.position, transform.rotation);
        Instantiate(Faster_Power_Up_Ref, transform.position, transform.rotation);
        ShipScript ship = FindObjectOfType<ShipScript>();

        if (ship != null)
        {
            ship.IncreaseScore(Score_Value);
        }

        Destroy(gameObject);
    }
}
