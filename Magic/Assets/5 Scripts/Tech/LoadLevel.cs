using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    public bool black = true;
    public int number;
    public void Load(int level)
    {
        Character.combination = 0;
        StartCoroutine(NextLevel(level));
    }
    private void Start()
    {
        Character.combination = 0;
        if (black)
        {
            StartCoroutine(ThisLevel());
        }
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
    public IEnumerator NextLevel(int level)
    {
        Image image = GameObject.Find("Imagelvl").GetComponent<Image>();
        for (float bright = 0; bright < 1; bright += Time.deltaTime)
        {
            image.color = new Color(0, 0, 0, bright);
            yield return new WaitForSeconds(0.005f);
        }
        SceneManager.LoadScene(level);
    }
}
