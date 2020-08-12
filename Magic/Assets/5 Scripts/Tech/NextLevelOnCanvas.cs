using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NextLevelOnCanvas : MonoBehaviour
{
    public void Next(int lvl)
    {
        GameObject.Find("Great").GetComponent<Animator>().SetBool("Next",true);
        StartCoroutine(GoToMap());
    }

    public IEnumerator GoToMap()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }
}
