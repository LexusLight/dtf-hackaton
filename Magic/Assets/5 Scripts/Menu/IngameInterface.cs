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
        Character.pointer = (Character.pointer == 2) ? 0 : Character.pointer + 1;
        SpellItem.PointerColor();
        GameObject.Find("Pointer").GetComponent<Text>().text = (Character.pointer + 1).ToString();
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
