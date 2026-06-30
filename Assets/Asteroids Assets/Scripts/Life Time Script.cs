using UnityEngine;

public class LifeTimeScript : MonoBehaviour
{
    public float Life_Time = 5f;

    private float Timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= Life_Time)
        {

            Destroy(gameObject);
        }
    }
}

