using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuAppearance : MonoBehaviour
{
    private Image Img;
    public Image Logo;
    public Image Mw;
    public Image Ll;
    public Image Interface;
    void Start()
    {
        Interface.GetComponent<Button>().enabled = false;
        Img = GetComponent<Image>();
        Img.color = new Color(0, 0, 0, 255);
        Logo.color = new Color(255, 255, 255, 0);
        Mw.color = new Color(255, 165, 246, 0);
        Ll.color = new Color(255, 165, 246, 0);
        StartCoroutine(Appearance());
    }
    IEnumerator Appearance()
    {
        Img.color = new Color(0, 0, 0, 255);
        for (float bright = 0; bright < 1; bright += Time.deltaTime)
        {
            Logo.color = new Color(255, 255, 255, bright);
            Mw.color = new Color(255, 165, 246, bright);
            Ll.color = new Color(255, 165, 246, bright);
            yield return new WaitForSeconds(0.005f);
        }
        yield return new WaitForSeconds(2f);
        for (float bright = 1; bright > 0; bright -= Time.deltaTime * 2)
        {
            Logo.color = new Color(255, 255, 255, bright);
            Mw.color = new Color(255, 165, 246, bright);
            Ll.color = new Color(255, 165, 246, bright);
            yield return new WaitForSeconds(0.002f);
        }
        Logo.color = new Color(255, 255, 255, 0);
        Mw.color = new Color(255, 165, 246, 0);
        Ll.color = new Color(255, 165, 246, 0);
        yield return new WaitForSeconds(0.5f);
        for (float bright = 1; bright > 0; bright -= Time.deltaTime * 2)
        {
            Img.color = new Color(0, 0, 0, bright);
            yield return new WaitForSeconds(0.005f);
        }
        Img.color = new Color(0, 0, 0, 0);
        Interface.GetComponent<Button>().enabled = true;

    }
}