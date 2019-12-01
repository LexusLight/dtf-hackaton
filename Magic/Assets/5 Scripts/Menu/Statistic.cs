using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statistic : MonoBehaviour
{
    static public int lvl;
    private void Start()
    {
        lvl = Character.LvlDone;
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
            }
        }
    }
}
