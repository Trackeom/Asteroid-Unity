using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ManagerScript : MonoBehaviour
{
    public float Inaccuracy = 2f;
    public GameObject[] Meteor_Refs;
    public GameObject[] OMeteor_Refs;
    public GameObject[] Turret_Refs;
    public bool Spawn_OMeteors = false;
    public bool Spawn_Turret = false;

    public float Check_Interval = 3f;
    public float Push_Force = 100f;
    public int Spawn_Meteor_Threshold = 5; //how many metoers on the screen (based on MetorScript.SpawnValue
    public int Spawn_OMeteor_Threshold = 10; //how many Ometoers on the screen (based on ObsidianMetorScript.SpawnValue
    public int Spawn_Turret_Threshold = 15;

    private float Check_Timer = 0;
    IEnumerator MeteorIncreaser()
    {
        yield return new WaitForSeconds(1);
        Spawn_Meteor_Threshold = Spawn_Meteor_Threshold * 2;
        yield return new WaitForSeconds(1);
        Spawn_OMeteors = true;
        yield return new WaitForSeconds(1);
        Spawn_Turret = true;
    }


    //timer example
    IEnumerator TimerFunction()
    {
        //will loop forever
        while (true)
        {
            //wait this long, then do something
            yield return new WaitForSeconds(60);
        }
    }


    private void Start()
    {
        StartCoroutine(MeteorIncreaser());

    }
    // Update is called once per frame
    void Update()
    {
        Check_Timer += Time.deltaTime;

        if (Check_Timer > Check_Interval)
        {
            Check_Timer = 0f;
            {
                if (Total_Meteor_Value() < Spawn_Meteor_Threshold)
                {
                    Spawn_New_Meteor();
                }
                if (Spawn_OMeteors == true)
                {
                    if (Total_OMeteor_Value() < Spawn_OMeteor_Threshold)
                    {
                        Spawn_New_OMeteor();
                    }
                }
                if (Spawn_Turret == true)
                {
                    if (Total_Turret_Value() < Spawn_Turret_Threshold)
                    {
                        Spawn_New_Turret();
                    }
                }
                
            }
        }
    }

    // Triggers when called
    public void Spawn_New_Meteor()
    {
        int Meteor_Index = Random.Range(0, Meteor_Refs.Length);
        GameObject Meteor_Ref = Meteor_Refs[Meteor_Index];
        Vector3 Spawn_Point = OffScreenSpawnPoint();
        GameObject Meteors = Instantiate(Meteor_Ref, Spawn_Point, transform.rotation);
        Vector2 force = PushDirection(Spawn_Point) * Push_Force;
        Rigidbody2D rb = Meteors.GetComponent<Rigidbody2D>();
        rb.AddForce(force);
    }

    public int Total_Meteor_Value()
    {
        MeteorScript[] Meteors = FindObjectsByType<MeteorScript>(FindObjectsSortMode.None);
        int value = 0;
        for (int n = 0; n < Meteors.Length; n++)
        {
            value += Meteors[n].Spawn_Value;
        }
        return value;
    }

    // Triggers when called
    public void Spawn_New_OMeteor()
    {
        int Meteor_Index = Random.Range(0, OMeteor_Refs.Length);
        GameObject OMeteor_Ref = OMeteor_Refs[Meteor_Index];
        Vector3 Spawn_Point = OffScreenSpawnPoint();
        GameObject OMeteors = Instantiate(OMeteor_Ref, Spawn_Point, transform.rotation);
        Vector2 force = PushDirection(Spawn_Point) * Push_Force;
        Rigidbody2D rb = OMeteors.GetComponent<Rigidbody2D>();
        rb.AddForce(force);
    }

    public int Total_OMeteor_Value()
    {
        ObsidianMeteorScript[] OMeteors = FindObjectsByType<ObsidianMeteorScript>(FindObjectsSortMode.None);
        int value = 0;
        for (int n = 0; n < OMeteors.Length; n++)
        {
            value += OMeteors[n].Spawn_Value;
        }
        return value;
    }
    public void Spawn_New_Turret()
    {
        int Turret_Index = Random.Range(0, Turret_Refs.Length);
        GameObject Turret_Ref = Turret_Refs[Turret_Index];
        Vector3 Spawn_Point = OffScreenSpawnPoint();
        GameObject Turrets = Instantiate(Turret_Ref, Spawn_Point, transform.rotation);
        //Vector2 force = PushDirection(Spawn_Point) * Push_Force;
        //Rigidbody2D rb = Turrets.GetComponent<Rigidbody2D>();
        //rb.AddForce(force);
    }

    public int Total_Turret_Value()
    {
        AlienTurretScript[] Turret = FindObjectsByType<AlienTurretScript>(FindObjectsSortMode.None);
        int value = 0;
        for (int n = 0; n < Turret.Length; n++)
        {
            value += Turret[n].Spawn_Value;
        }
        return value;
    }

    public Vector3 OffScreenSpawnPoint()
    {
        Vector2 random_Pos = Random.insideUnitCircle;
        Vector2 direction = random_Pos.normalized;
        Vector2 final_Pos = (Vector2)transform.position + direction * 2f;
        Vector3 result = Camera.main.ViewportToWorldPoint(final_Pos);
        result.z = transform.position.z;
        return result;
    }

    public Vector2 PushDirection(Vector2 Form)
    {
        Vector2 Miss = Random.insideUnitCircle * Inaccuracy;
        Vector2 Destonation = (Vector2)transform.position + Miss;
        Vector2 Direction = (Destonation - Form).normalized;
        return Direction;
    }
}
