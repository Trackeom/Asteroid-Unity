using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShipScript : MonoBehaviour
{
    public AudioSource Retro_Funk;
    public AudioSource Ship_Damage;
    public AudioSource Ship_Turn;
    public AudioSource Ship_Thrust;
    public float Firing_Rate = 0.33f;
    public float Bigger_Firing_Rate = 0.66f;
    public float Faster_Firing_Rate = 0.1675f;
    public float Engine_Power = 10f;
    public float Turn_Power = -10f;
    public float Max_HP = 3f;
    public float Current_HP;
    public GameObject Bullet_Ref;
    public float Bullet_Speed = 150f;
    public GameObject Bigger_Bullet_Ref;
    public GameObject Faster_Bullet_Ref;
    public float Bigger_Bullet_Speed = 150f;
    public float Faster_Bullet_Speed = 200;
    public GameObject Explosion_Ref;
    public ScreenFlash Flash;
    public float Teleport = 0;
    public int Extra_Life = 0;
    public float Bigger_Fire_Timer = 0f;
    public float Faster_Fire_Timer = 0f;
    public float Fast_Count_Down = 0f;
    public float Big_Count_Down = 0f;
    public bool Fast_Power_Up = false;
    public bool Big_Power_Up = false;
    public bool Default_Form = true;
    public int Life_Time_Seconds = 0;
    public int Life_Time_Minutes = 0;
    public int Life_Time_Hours = 0;
    public int Life_Time_Days = 0;

    private Rigidbody2D rb2D;
    private SpriteRenderer Ship_Skin;
    private float Fire_Timer = 0f;
    private int Score = 0;
    private int ELScore = 0;


    const int SCORE_FOR_LIFE = 1000;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SimpleTime());
        Fast_Count_Down = Fast_Count_Down + Time.deltaTime;
        Big_Count_Down = Big_Count_Down + Time.deltaTime;
        Current_HP = Max_HP;
        rb2D = GetComponent<Rigidbody2D>();
        Retro_Funk.Play();
    }

    IEnumerator SimpleTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Life_Time_Seconds = Life_Time_Seconds + 1;
            if (Life_Time_Seconds > 60)
            {
                Life_Time_Seconds = 0;
                Life_Time_Minutes += 1;

                if (Life_Time_Minutes > 60)
                {
                    Life_Time_Minutes = 0;
                    Life_Time_Hours += 1;

                    if (Life_Time_Hours > 24)
                    {
                        Life_Time_Hours = 0;
                        Life_Time_Days += 1;

                        //                      ( - DECORATION USE ONLY - )

                        //                      DO NOT STAY UP FOR DAYS I BEG YOU

                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Default_Form == true)
        {
            Update_Firing();
            Ship_Skin = GetComponent<SpriteRenderer>();
            Ship_Skin.color = Color.white;
        }

        if (Big_Power_Up == true)
        {
            Update_Bigger_Firing();
            Ship_Skin = GetComponent<SpriteRenderer>();
            Ship_Skin.color = Color.yellow;
        }

        if (Fast_Power_Up == true)
        {
            Update_Faster_Firing();
            Ship_Skin = GetComponent<SpriteRenderer>();
            Ship_Skin.color = Color.lightBlue;
        }

        if (Big_Power_Up == false)
        {
            Big_Count_Down = 2001;
        }

        if (Fast_Power_Up == false)
        {
            Fast_Count_Down = 2001;
        }
        float H = Input.GetAxis("Horizontal");
        float V = Input.GetAxis("Vertical");
        Apply_Thrust(V);
        Apply_Torque(H);

        Big_Count_Down -= 1;
        Fast_Count_Down -= 1;
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
            if (amount == 0)
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
            if (Extra_Life > 0)
            {
                Instantiate(Explosion_Ref, transform.position, transform.rotation);
                Extra_Life = Extra_Life - 1;
                Current_HP = Max_HP;
            }
            else
            {
                Explode();
            }
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
        Reset_Progress();
    }

    public void Fire_Bullet()
    {
        GameObject Bullet = Instantiate(Bullet_Ref, transform.position, transform.rotation);
        Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
        Vector2 Force = transform.up * Bullet_Speed;
        rb.AddForce(Force);
    }
    public void Fire_Fast_Bullet()
    {
        GameObject Faster_Bullet = Instantiate(Faster_Bullet_Ref, transform.position, transform.rotation);
        Rigidbody2D rb = Faster_Bullet.GetComponent<Rigidbody2D>();
        Vector2 Force = transform.up * Faster_Bullet_Speed;
        rb.AddForce(Force);
    }

    public void Fire_Big_Bullet()
    {
        GameObject Bigger_Bullet = Instantiate(Bigger_Bullet_Ref, transform.position, transform.rotation);
        Rigidbody2D rb = Bigger_Bullet.GetComponent<Rigidbody2D>();
        Vector2 Force = transform.up * Bigger_Bullet_Speed;
        rb.AddForce(Force);
    }

    // Triggers when called
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

    private void Update_Bigger_Firing()
    {
        bool Is_Firing = Input.GetButton("Fire1");
        Bigger_Fire_Timer = Bigger_Fire_Timer - Time.deltaTime;
        if (Is_Firing == true && Bigger_Fire_Timer <= 0)
        {
            Fire_Big_Bullet();
            Bigger_Fire_Timer = Bigger_Firing_Rate;
        }

        if (Big_Count_Down <= 0)
        {
            Big_Power_Up = false;
            Ship_Skin = GetComponent<SpriteRenderer>();
            Ship_Skin.color = Color.white;
            Default_Form = true;
            Debug.Log("Out of time");
            Big_Count_Down = 2000;
        }
    }

    private void Update_Faster_Firing()
    {
        bool Is_Firing = Input.GetButton("Fire1");
        Faster_Fire_Timer = Faster_Fire_Timer - Time.deltaTime;
        if (Is_Firing == true && Faster_Fire_Timer <= 0)
        {
            Fire_Fast_Bullet();
            Faster_Fire_Timer = Faster_Firing_Rate;
        }

        if (Fast_Count_Down <= 0)
        {
            Fast_Power_Up = false;
            Ship_Skin = GetComponent<SpriteRenderer>();
            Ship_Skin.color = Color.white;
            Default_Form = true;
            Debug.Log("Out of time");
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

    public int GetELScore()
    {
        return ELScore;
        // if EL_score is greager than 1000 then add +1 to Extra Life 
    }

    public void IncreaseScore(int addScore)
    {
        Score = Score + addScore;
        ELScore = ELScore + addScore;

        if (ELScore >= SCORE_FOR_LIFE)
        {
            ELScore = 0;
            Extra_Life = Extra_Life + 1;
        }
    }

    public int GetScore()
    {
        return Score;
    }

    public void OnCollisionEnter2D(Collision2D Collision)
    {
        if (Collision.gameObject.CompareTag("Big Power Up"))
        {
            Big_Power_Up = true;
            Default_Form = false;
            Destroy(Collision.gameObject);
        }

        if (Collision.gameObject.CompareTag("Fast Power Up"))
        {
            Fast_Power_Up = true;
            Default_Form = false;
            Destroy(Collision.gameObject);
        }
    }

    public void Reset_Progress()
    {

    }
}


    //Setup stuff
    //remove ireelevant variables EG: timer stuff, bool, etc.


    //Logic - on collision
    //when you pick up a power up - check its tag
    //if its the tag you want, increase the number of bullets (EG: by 10)
    //turn on the slider

    //Logic - shooting
    //When shooting, check if you have more than 0 'Shots', if so, do a big bullet
    //everytime you shoot a big bullet, remove 1 from the 'NumberOfShots'.
    //when its at 0, simply turn off the slider

    //Reference the slider
    //for the UI, you need to reference the 'Slider'
        //public Slider bigBulletSlider;
    //Reference - changing the value
        //bigBulletSlider.Value = NumberOfBullets;

}

