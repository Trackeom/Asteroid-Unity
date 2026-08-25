using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class ScreenFlashScript : MonoBehaviour
{
    public float Flash_Duration = 0.33f;

    private Image Flash_Image;
    private Color Image_Colour;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Flash_Image = GetComponent<Image>();
        Image_Colour = Flash_Image.color;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator Flash_Routine()
    {
        float timer = 0f;
        float t = 0f;
        float alphaForm = 1f;
        float alphaTo = 0f;

        while (t < 1f)
        {
            timer += Time.deltaTime;
            t = Mathf.Clamp01(timer / Flash_Duration);
            float alpha = Mathf.Lerp(alphaForm, alphaTo, t);
            Color col = Image_Colour;
            col.a = alpha;
            Flash_Image.color = col;
            yield return new WaitForEndOfFrame();
        }
    }
}