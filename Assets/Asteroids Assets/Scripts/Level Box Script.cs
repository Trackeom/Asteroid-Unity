using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class LevelBoxScript : MonoBehaviour
{
    public TMP_Text Level_Text_Box;
    public GameObject Level_Panel;

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
            Level_Text_Box.text = "Lv " + Ship.Current_Level.ToString();
        }
    }
}
