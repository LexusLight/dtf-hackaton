using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NextLevelOnCanvas : MonoBehaviour
{
    public void Next(int lvl)
    {
        GameObject.Find("Great").GetComponent<Animator>().SetBool("Next",true);
        StartCoroutine(GoToMap(1));
    }
    public void Reload()
    {
        GameObject.Find("Cringe").GetComponent<Animator>().SetBool("Next", true);
        StartCoroutine(GoToMap(Statistic.thislvl));
    }

    public IEnumerator GoToMap(int i)
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(i);
    }
}
