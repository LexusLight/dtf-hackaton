using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameInterface : MonoBehaviour
{
    private void Start()
    {
        if(Statistic.Joyst == 1)
        {
            GameObject.Find("Throw").SetActive(false);
            GameObject.Find("Fixed Joystick").SetActive(false);
        }
    }

    public void ChangePointer()
    {
        if (Character.combination[0] == 0 && Character.combination[1] == 0 && Character.combination[2] == 0) return;
        Character.pointer = (Character.pointer == 2) ? 0 : Character.pointer + 1;
        SpellItem.PointerColor();
        GameObject.Find("Pointer").GetComponent<Text>().text = (Character.pointer + 1).ToString();
        if (Character.combination[Character.pointer] == 0) ChangePointer();
    }

    public void MenuSwipe(Animator Anim)
    {
        print(1);
        if (Anim.GetBool("Open"))
        Anim.SetBool("Open", false);
        else
            Anim.SetBool("Open", true);
    }
}
