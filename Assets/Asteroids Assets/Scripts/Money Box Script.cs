using TMPro;
using UnityEngine;

public class MoneyBoxScript : MonoBehaviour
{
    public TMP_Text Credet_Text_Box;
    public GameObject Credet_Panel;

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
            Credet_Text_Box.text = Ship.GetPay().ToString();
        }
    }
}
