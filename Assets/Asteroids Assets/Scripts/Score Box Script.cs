using TMPro;
using UnityEngine;

public class ScoreBoxScript : MonoBehaviour
{
    public TMP_Text Score_Text_Box;
    public GameObject Score_Panel;

    private ShipScript Ship;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Ship = FindObjectOfType<ShipScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Ship != null)
        {
            Score_Text_Box.text = Ship.Score.ToString();
        }
    }
}
