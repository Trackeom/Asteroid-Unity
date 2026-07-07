using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    public float Inaccuracy = 2f;
    public GameObject[] Meteor_Refs;
    public float Check_Interval = 3f;
    public float Push_Force = 100f;
    public int Spawn_Threshold =10;

    private float Check_Timer = 0;

    void Update()
    {
        Check_Timer += Time.deltaTime;
        if (Check_Timer > Check_Interval)
        {
            Check_Timer = 0f;
            {
                if (Total_Meteor_Value() < Spawn_Threshold)
                {
                    Spawn_New_Meteor();
                }
            }
        }
    }

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
