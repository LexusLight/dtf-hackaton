using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statistic : MonoBehaviour
{
    public static int Joyst = 0; 
    public static int LvlDone = 2;
    static public int lvl;
    static public int thislvl;
    void Awake()
    {
        LvlDone = (PlayerPrefs.GetInt("lvl")==0)? 2 : PlayerPrefs.GetInt("lvl");
        Joyst = PlayerPrefs.GetInt("Joyst");
    }

    private void Start()
    {
        lvl = LvlDone;
        GameObject[] Mass = GameObject.FindGameObjectsWithTag("Point");
        foreach (GameObject item in Mass)
        {
            if(item.GetComponent<MenuPoint>().Id <= lvl)
            {
                item.GetComponent<Animator>().SetBool("Opened", true);
            }
            else
            {
                item.GetComponent<Animator>().SetBool("Opened", false);
            }

            if (item.GetComponent<MenuPoint>().Id < lvl)
            {
                item.GetComponent<Animator>().SetBool("Complete", true);
            }
            else
            {
                item.GetComponent<Animator>().SetBool("Complete", false);
            }

            if (lvl != item.GetComponent<MenuPoint>().Id) {
                item.GetComponent<Animator>().SetBool("Choised", false);
            }else
            {
                item.GetComponent<Animator>().SetBool("Choised", true);
                MenuCamera.pointX = item.transform.position.x;
                MenuCamera.pointY = item.transform.position.y;
                GameObject.Find("Text1").GetComponent<Text>().text = item.GetComponent<MenuPoint>().NameLvl;
                
            }
        }
    }
}
