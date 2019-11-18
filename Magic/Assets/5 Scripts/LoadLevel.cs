using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    public int number;
    public void Load()
    {
        Character.combination = 0;
        StartCoroutine(NextLevel());
    }
    private void Start()
    {
        Character.combination = 0;
        StartCoroutine(ThisLevel());
    }
    public static IEnumerator ThisLevel()
    {
        Image image = GameObject.Find("Imagelvl").GetComponent<Image>();
        for (float bright = 1; bright > 0; bright -= Time.deltaTime)
        {
            image.color = new Color(0, 0, 0, bright);
            yield return new WaitForSeconds(0.005f);
        }
    }
    public IEnumerator NextLevel()
    {
        Image image = GameObject.Find("Imagelvl").GetComponent<Image>();
        for (float bright = 0; bright < 1; bright += Time.deltaTime)
        {
            image.color = new Color(0, 0, 0, bright);
            yield return new WaitForSeconds(0.005f);
        }
        SceneManager.LoadScene(number+1);
    }
}
