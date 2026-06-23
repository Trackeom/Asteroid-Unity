using UnityEngine;

public class ShipScript : MonoBehaviour
{
    public float Engine_Power = 10f;
    public float Turn_Power = -10f;
    public float Max_HP = 3f;
    public float Current_HP;

    private Rigidbody2D rb2D;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Current_HP = Max_HP;
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

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
        if (Current_HP <= 0f)
        {
            Explode();
        }
    }

    public void Explode()
    {
        Debug.Log("Game Over");
        Destroy(gameObject);
    }
}    
