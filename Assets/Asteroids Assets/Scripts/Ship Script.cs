using UnityEngine;

public class ShipScript : MonoBehaviour
{
    public float Firing_Rate = 0.33f;
    public float Engine_Power = 10f;
    public float Turn_Power = -10f;
    public float Max_HP = 3f;
    public float Current_HP;
    public GameObject Bullet_Ref;
    public float Bullet_Speed = 100f;
    public GameObject Explosion_Ref;

    private Rigidbody2D rb2D;
    private float Fire_Timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Current_HP = Max_HP;
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Update_Firing();

        float H = Input.GetAxis("Horizontal");
        float V = Input.GetAxis("Vertical");
        Apply_Thrust(V);
        Apply_Torque(H);
    }

    private void Apply_Thrust(float amount)
    {
        Vector2 Thrust = transform.up * Engine_Power * Time.deltaTime * amount;
        rb2D.AddForce(Thrust);
    }

    private void Apply_Torque(float amount)
    {
        float Torque = amount * Turn_Power * Time.deltaTime;
        rb2D.AddTorque(Torque);
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
        Debug.Log("Game Over");
        Destroy(gameObject);
    }

    public void Fire_Bullet()
    {
        GameObject Bullet = Instantiate(Bullet_Ref, transform.position, transform.rotation);
        Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
        Vector2 Force = transform.up * Bullet_Speed;
        rb.AddForce(Force);
    }

    private void Update_Firing()
    {
        bool Is_Firing = Input.GetButton("Fire1");
        Fire_Timer = Fire_Timer - Time.deltaTime;
        if (Is_Firing && Fire_Timer <= 0f)
        {
            Fire_Bullet();
            Fire_Timer = Firing_Rate;
        }
    }

}    
