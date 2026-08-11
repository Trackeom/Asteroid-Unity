using TMPro;
using UnityEngine;

public class ELScoreBoxScript : MonoBehaviour
{
    public TMP_Text ELScore_Text_Box;
    public GameObject ELScore_Panel;

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
            ELScore_Text_Box.text = "+  " + Ship.Extra_Life.ToString();
        }
    }
}
