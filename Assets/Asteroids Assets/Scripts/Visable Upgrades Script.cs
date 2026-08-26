using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VisableUpgradesScript : MonoBehaviour
{
    public GameObject Upgrade_Panal_Ref;
    public ShipScript Ship;

    public void Start()
    {
        Upgrade_Panal_Ref.SetActive(false);
    }

    public void Invisable()
    {
        Upgrade_Panal_Ref.SetActive(false);
        Ship.Now_Level_Up();
    }

    public void Visable()
    {
        Upgrade_Panal_Ref.SetActive(true);
        Debug.Log("Visable");
    }
}
