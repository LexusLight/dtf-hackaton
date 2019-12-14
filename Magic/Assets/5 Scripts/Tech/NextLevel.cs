using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public int NumScene;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Character.combination = new int[3];
            StartCoroutine(NextLevel1());
        }
    }
    public IEnumerator NextLevel1()
    {
        Image image = GameObject.Find("Imagelvl").GetComponent<Image>();
        for (float bright = 0; bright < 1; bright += Time.deltaTime)
        {
            image.color = new Color(0, 0, 0, bright);
            yield return new WaitForSeconds(0.005f);
        }
        if (PlayerPrefs.GetInt("lvl") < 1)
        {
            PlayerPrefs.SetInt("lvl", 2);
            PlayerPrefs.Save();
        }
        if (PlayerPrefs.GetInt("lvl") == Statistic.LvlDone)
        {
            PlayerPrefs.SetInt("lvl", Statistic.LvlDone+1);
            PlayerPrefs.Save();
        }
        SceneManager.LoadScene(NumScene);//внимание
    }
}
