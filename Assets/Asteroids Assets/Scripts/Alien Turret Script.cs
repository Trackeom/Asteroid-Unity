using System.Collections;
using UnityEngine;

public class AlienTurretScript : MonoBehaviour
{
    public int Spawn_Value = 10;
    public float Fire_Timer = 1f;
    public GameObject Bullet_Ref;
    public float Bullet_Speed = 100;
    public float Collision_Damage = 1f;
    public float Max_HP = 3f;
    public float Current_HP;
    public GameObject Explosion_Ref;
    public GameObject Faster_Power_Up_Ref;
    public GameObject Fuel_Drop_Ref;
    public int Score_Value = 75;
    public float Timer = 0f;
    public bool Moving;
    ShipScript Ship;
    public SpriteRenderer mySpriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Timer = Time.deltaTime;
        Current_HP = Max_HP;
        Ship = FindObjectOfType<ShipScript>();
        if (Ship != null)
        {
            Ship.Enemy_Counter += 1;
        }

        StartCoroutine (Move_To_Target());
    }

    IEnumerator Move_To_Target()
    {
        while (mySpriteRenderer.isVisible == false)
        {
            if (Ship != null)
            {
                transform.position = Vector3.Lerp(transform.position, Ship.transform.position, Time.deltaTime);
            }
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(1); //wait onscreen and look at the player before moving

        float deltaTime = 0;
        while(deltaTime < 0.5) //how many seconds to move towards the player
        {
            deltaTime += Time.deltaTime;
            if (Ship != null)
            {
                transform.position = Vector3.Lerp(transform.position, Ship.transform.position, Time.deltaTime);
            }
            yield return new WaitForEndOfFrame();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Ship != null)
        {
            Fire_Timer += Time.deltaTime;
            Vector3 direction = Ship.transform.position - transform.position;
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
        if (Random.Range(0, 10) == 5)
        {
            Instantiate(Faster_Power_Up_Ref, transform.position, transform.rotation);
        }

        ShipScript Ship = FindObjectOfType<ShipScript>();

        if (Ship != null)
        {
            Ship.IncreaseScore(Score_Value);
            Ship.Enemy_Counter -= 1;
        }
        Destroy(gameObject);
    }
}
