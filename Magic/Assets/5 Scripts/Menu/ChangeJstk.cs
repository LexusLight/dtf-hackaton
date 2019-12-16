using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeJstk : MonoBehaviour
{
    public void Start()
    {
        GameObject.Find("JJ").GetComponent<Animator>().SetInteger("Yes", Statistic.Joyst);
    }
    public void Change()
    {
        Statistic.Joyst = (Statistic.Joyst == 0) ? 1 : 0;
        PlayerPrefs.SetInt("Joyst", Statistic.Joyst);
        PlayerPrefs.Save();
        GameObject.Find("JJ").GetComponent<Animator>().SetInteger("Yes", Statistic.Joyst);
    }
}
