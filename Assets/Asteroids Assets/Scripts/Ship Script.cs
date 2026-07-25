using UnityEngine;

public class ShipScript : MonoBehaviour
{
    public AudioSource Retro_Funk;
    public AudioSource Ship_Damage;
    public AudioSource Ship_Turn;
    public AudioSource Ship_Thrust;
    public float Firing_Rate = 0.33f;
    public float Engine_Power = 10f;
    public float Turn_Power = -10f;
    public float Max_HP = 3f;
    public float Current_HP;
    public GameObject Bullet_Ref;
    public float Bullet_Speed = 100f;
    public GameObject Explosion_Ref;
    public ScreenFlash Flash;
    public int Score = 0;

    private Rigidbody2D rb2D;
    private float Fire_Timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Current_HP = Max_HP;
        rb2D = GetComponent<Rigidbody2D>();
        Retro_Funk.Play();
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
        if (amount > 0f)
        {
            Vector2 Thrust = transform.up * Engine_Power * Time.deltaTime * amount;
            rb2D.AddForce(Thrust);

            if (Ship_Thrust.isPlaying == false)
            {
                Ship_Thrust.Play();

            }
        }
        else
        {
            if (Ship_Thrust.isPlaying == true)
            {
                Ship_Thrust.Stop();
            }
        }
    }
    

    private void Apply_Torque(float amount)
    {
        float Torque = amount * Turn_Power * Time.deltaTime;
        rb2D.AddTorque(Torque);
        if (Ship_Turn.isPlaying == true)
        {
            if(amount == 0)
            {
                Ship_Turn.Stop();
            }
        }
        if (Ship_Turn.isPlaying == false)
        {
            if (amount != 0)
            {
                Ship_Turn.Play();
            }
        }
    }

    public void Take_Damage(float damage)
    {
        Current_HP = Current_HP - damage;
        if (Current_HP <= 0f)
        {
            Explode();
        }
        Ship_Damage.Play();
        StartCoroutine(Flash.Flash_Routine());
    }

    public void Explode()
    {
        Instantiate(Explosion_Ref, transform.position, transform.rotation);
        Debug.Log("Game Over");
        Retro_Funk.Stop();
        Game_Over();
        Destroy(gameObject);
    }

    public void Fire_Bullet()
    {
        GameObject Bullet = Instantiate(Bullet_Ref, transform.position, transform.rotation);
        Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
        Vector2 Force = transform.up * Bullet_Speed;
        rb.AddForce(Force);
    }

    // Triggers when called
    private void Update_Firing()
    {
        bool Is_Firing = Input.GetButton("Fire");
        Fire_Timer = Fire_Timer - Time.deltaTime;
        if (Is_Firing && Fire_Timer <= 0f)
        {
            Fire_Bullet();
            Fire_Timer = Firing_Rate;
        }
    }

    public int Get_High_Score()
    {
    return PlayerPrefs.GetInt("High Score", 0);
    }

    public void Set_High_Score(int score)
    {
        PlayerPrefs.SetInt("High Score", score);
    }

    // Triggers when called
    public void Game_Over()
    {
        // If 
        bool Celebrate_High_Score = false;
        if (Score > Get_High_Score())
        {
            Set_High_Score(Score);
            Celebrate_High_Score = true;
        }

        GameOverScript gameOver = FindObjectOfType<GameOverScript>();
        if (gameOver != null)
        {
            gameOver.Show(Celebrate_High_Score);
        }

    }
}    
