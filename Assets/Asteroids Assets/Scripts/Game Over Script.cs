using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public TMP_Text Score_Text_Box, High_Score_Text_Box;
    public GameObject Score_Panel, Celebrate;

    private ShipScript Ship;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Ship = FindObjectOfType<ShipScript>();
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show (bool Celebrate_High_Score)
    {
        Score_Text_Box.text = Ship.Score.ToString();
        High_Score_Text_Box.text = Ship.Get_High_Score().ToString();

        Score_Panel.SetActive (true);
        Celebrate.SetActive(Celebrate_High_Score);
    }

    public void Hide()
    {
        Score_Panel.SetActive (false);
    }

    public void Press_Try_Again()
    {
        SceneManager.LoadScene("Play");
    }

    public void Press_Back()
    {
        SceneManager.LoadScene("Menu");
    }
}
