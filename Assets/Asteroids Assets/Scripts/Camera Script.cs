using System.Collections;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private IEnumerator Shake_Routine()
    {
       /
        Vector3 originalPos = transform.position;
        for(int n = 0; n < Iterations;  n++)
        {
            Vector3 pos = Random.insideUnitCircle * Shake_Amount;
            transform.position = transform.position + pos;
            yield return new WaitForSeconds(Shake_Delay);
        }
        transform.position = originalPos;
        yield return null;
       
    }*/
}
