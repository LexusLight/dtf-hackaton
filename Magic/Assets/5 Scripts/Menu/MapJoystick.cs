using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapJoystick : MonoBehaviour
{
    static int idjstk = 0;
    bool yes = true;
    Text Text1;

    private void Start()
    {
        Text1 = GameObject.Find("Text1").GetComponent<Text>();
    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 && yes)
        {
            yes = false;
            StartCoroutine(JoystickMap());
        }
        if (Statistic.Joyst == 1 && (Input.GetKeyDown("return") || Input.GetKeyDown("enter")))
        {
            GameObject.Find("LevelMananger").GetComponent<LoadLevel>().LoadFromMenu(idjstk);
        }
    }

    IEnumerator JoystickMap()
    {
        idjstk = Statistic.lvl;
        GameObject[] Points;
        Points = GameObject.FindGameObjectsWithTag("Point");
        if (Statistic.Joyst == 1)
        {
            if (Input.GetAxis("Horizontal") > 0) idjstk = (idjstk == Statistic.LvlDone) ? idjstk : idjstk + 1;
            if (Input.GetAxis("Horizontal") < 0) idjstk = (idjstk < 3) ? 2 : idjstk - 1; ;
            print(idjstk);
            Statistic.lvl = idjstk;
            foreach (GameObject item in Points)
            {
                foreach (GameObject item1 in Points)
                {
                    item.GetComponent<Animator>().SetBool("Choised", false);
                }
                if (item.GetComponent<MenuPoint>().Id == idjstk)
                {
                    MenuCamera.pointX = item.transform.position.x;
                    MenuCamera.pointY = item.transform.position.y;
                    Statistic.thislvl = idjstk;
                    Text1.text = item.GetComponent<MenuPoint>().NameLvl;
                    item.GetComponent<Animator>().SetBool("Choised", true);
                }
            }
        }
        yield return new WaitForSeconds(0.3f);
        yes = true;
    }
}
