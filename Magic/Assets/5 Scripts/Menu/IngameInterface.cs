using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameInterface : MonoBehaviour
{
    public void ChangePointer()
    {
        Character.pointer = (Character.pointer == 2) ? 0 : Character.pointer + 1;
        SpellItem.PointerColor();
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
