using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputText : MonoBehaviour
{
    public int string_num = 0;
    public string str;
    Text text;

    void Awake()
    {
        text = gameObject.GetComponent<Text>();
        str = (Texts.Language == 1) ? Texts.Ru[string_num] : Texts.Eng[string_num];
        text.text = str;
    }
}
